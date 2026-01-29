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
    public DialogueEmotion CurrentEmotion = DialogueEmotion.Neutral;
    public bool IsDialogueActive = false;
    public List<SceneMakerObject> CreatedScenes = new List<SceneMakerObject>();
    public SceneMakerObject currentScene;
    public List<DialogueLine> LoadedDialogueLines = new List<DialogueLine>();
    public bool AutoAdvance = false;
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
      
        LoadDialouge("Scene 0");


    }


    public IEnumerator LoadDialouge(string sceneName)
    {
        LoadedDialogueLines.Clear();
        CurrentLineIndex = 0;
        var dayScene = CreatedScenes.Find(scene => scene.SceneName == sceneName);
        currentScene = dayScene;
        AutoAdvance = currentScene.AutoAdvance;

        yield return new WaitForSeconds(0.3f);
        LoadedDialogueLines = currentScene.DialogueLines;
        loadText(LoadedDialogueLines[CurrentLineIndex]);


    }
   




    public void loadText(DialogueLine chosenline)
    {
        PlayerDialougeText.text = chosenline.Line;
        playerImage.sprite = EmotionSprites[(int)chosenline.Emotion];
        IsDialogueActive = true;
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
           DialogueLine emptyLine = new DialogueLine(DialogueEmotion.Neutral, "");
            loadText(emptyLine);
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
    public DialogueEmotion Emotion;
    public DialogueLine(DialogueEmotion emotion, string line)
    {
        Emotion = emotion;
        Line = line;
    }

 
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
    public string SceneName;
    public List<DialogueLine> DialogueLines;
    public bool SceneCompleted;

  
}