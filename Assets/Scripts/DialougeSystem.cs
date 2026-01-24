using System.Collections.Generic;
using TMPro;
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

    public List<DialogueLine> LoadedDialogueLines = new List<DialogueLine>();

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
        InputSystem.actions.FindAction("NextRequest").performed += ctx => NextLine();

    }

    public void OnDestroy()
    {
        InputSystem.actions.FindAction("NextRequest").performed -= ctx => NextLine();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (LoadedDialogueLines.Count > 0)
        {
            loadText(LoadedDialogueLines[CurrentLineIndex]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void loadText(DialogueLine chosenline)
    {
        PlayerDialougeText.text = chosenline.Line;
        playerImage.sprite = EmotionSprites[(int)chosenline.Emotion];
    }

    public void NextLine()
    {
        if (CurrentLineIndex + 1 < LoadedDialogueLines.Count)
        {
            CurrentLineIndex++;
            loadText(LoadedDialogueLines[CurrentLineIndex]);
        }
    }
}

public enum DialogueEmotion
{
    Neutral,
    Happy,
    Sad,
    Angry,
    Surprised,
    Confident
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