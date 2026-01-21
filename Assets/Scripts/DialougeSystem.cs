using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialougeSystem : MonoBehaviour
{

    
    public int CurrentLineIndex = 0;

    
    public TextMeshProUGUI PlayerDialougeText;
    public DialogueEmotion CurrentEmotion = DialogueEmotion.Neutral;
    public List<DialogueLine> DialogueLines = new List<DialogueLine>();
    
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loadText(DialogueLines[CurrentLineIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void loadText(DialogueLine chosenline)
    {
        PlayerDialougeText.text = chosenline.Line;
        CurrentEmotion = chosenline.Emotion;
    }
}

public enum DialogueEmotion
{
    Neutral,
    Happy,
    Sad,
    Angry,
    Surprised
}