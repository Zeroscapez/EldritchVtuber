using System.Collections.Generic;
using UnityEngine;

public class DialougeActivator : MonoBehaviour
{
    public List<DialogueLine> DialogueLines = new List<DialogueLine>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateDialouge()
    {
        
        DialougeSystem dialougeSystem = DialougeSystem.Instance;
        if (dialougeSystem != null)
        {
            dialougeSystem.LoadedDialogueLines = DialogueLines;
            dialougeSystem.CurrentLineIndex = 0;
            dialougeSystem.loadText(dialougeSystem.LoadedDialogueLines[dialougeSystem.CurrentLineIndex]);
        }
    }
}
