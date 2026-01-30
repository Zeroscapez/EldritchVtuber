using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialougeSystem : MonoBehaviour
{

    public static DialougeSystem Instance;
    public int CurrentLineIndex = 0;

    public Image playerImage;
    public Sprite[] EmotionSprites;
    public TextMeshProUGUI PlayerDialougeText;
    public GameObject DialougeBox;
    public DialogueEmotion CurrentEmotion = DialogueEmotion.Neutral;
    public bool IsDialogueActive = false;
    public List<SceneMakerObject> CreatedScenes = new List<SceneMakerObject>();
    public SceneMakerObject currentScene;
    public List<DialogueLine> LoadedDialogueLines = new List<DialogueLine>();
    public bool AutoAdvance = false;


    [Header("Messaging App Dialouge")]
    public Transform MessageAppDialougePanel;
    public GameObject MessagingAppMessagePrefab;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

      
    

    }

    public void OnDestroy()
    {
       
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //PlayerDialougeText.text = "";
        //DialougeBox.SetActive(false);
    }

  


    public void LoadDialouge(string sceneName)
    {
        
        LoadedDialogueLines.Clear();
        CurrentLineIndex = 0;
        var dayScene = CreatedScenes.Find(scene => scene.SceneName == sceneName);

        if(dayScene.SceneCompleted)
        {
            DialogueLine emptyLine = new DialogueLine(Actor.Crystal,DialougeLineType.DialougeBox,DialogueEmotion.Neutral, "");
            loadText(emptyLine);
            IsDialogueActive = false;
           
        }
        currentScene = dayScene;
        AutoAdvance = currentScene.AutoAdvance;

        StartCoroutine(WaitforDialouge());


    }

    public IEnumerator WaitforDialouge()
    {
        yield return new WaitForSeconds(0.3f);
        LoadedDialogueLines = currentScene.DialogueLines;
        loadText(LoadedDialogueLines[CurrentLineIndex]);
    }

   


    private void loadText(DialogueLine chosenline)
    {
        if(chosenline.LineType == DialougeLineType.DialougeBox)
        {
            DialougeBox.SetActive(true);
            PlayerDialougeText.text = chosenline.Line;
            //playerImage.sprite = EmotionSprites[(int)chosenline.Emotion];
            IsDialogueActive = true;
        }

        if(chosenline.LineType == DialougeLineType.MessageApp)
        {
            MessagingAppManager.Instance.CreateMessage(chosenline);
            //playerImage.sprite = EmotionSprites[(int)chosenline.Emotion];
            IsDialogueActive = true;
        }
      
    }

    public void NextLine()
    {
        if ((CurrentLineIndex + 1 < LoadedDialogueLines.Count) && IsDialogueActive == true)
        {
            CurrentLineIndex++;
            loadText(LoadedDialogueLines[CurrentLineIndex]);
        }
        else
        {
            if(currentScene!= null)
            {
                //currentScene.SceneCompleted = true;
            }
         
            DialogueLine emptyLine = new DialogueLine(Actor.Crystal,DialougeLineType.DialougeBox,DialogueEmotion.Neutral, "");
            loadText(emptyLine);
           // DialougeBox.SetActive(false);
            IsDialogueActive = false;
        }
    }
}

public enum DialogueEmotion
{
    Neutral,
    Joy,
    Fear,
    Smug,
    Pout,
    Cry,
    Confused,
    Nervous
}

public class EmotionSpritePair
{
    public DialogueEmotion Emotion;
    public Sprite EmotionSprite;

   

}

[System.Serializable]
public struct DialogueLine
{
    [TextArea(3, 10)]
    public string Line;
    public Actor Actor;
    public DialogueEmotion Emotion;
    public DialougeLineType LineType;
    public DialogueLine(Actor actor, DialougeLineType linetype, DialogueEmotion emotion, string line)
    {
        Actor = actor;
        Emotion = emotion;
        Line = line;
        LineType = linetype;
    }

 
}

public enum Actor
{
    Crystal,
    Manager
}
public enum DialougeLineType
{
    MessageApp,
    DialougeBox
}

//[System.Serializable]
//public struct DayDialogueScenes
//{
//    public DayOfWeek Day;
//    public List<SceneDialouge> SceneDialogues;

//}

[System.Serializable]
public struct SceneDialouge
{
    public Actor Actor;
    public string SceneName;
    public List<DialogueLine> DialogueLines;
    public bool SceneCompleted;

  
}