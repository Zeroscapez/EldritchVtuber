using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private DayOfWeek currentDay;

    public DialogueRunner dialogueBoxDialogueRunner;
    public DialogueRunner messageAppDialogueRunner;
    public DialogueRunner chatDialogueRunner;

    private DialogueRunner activeDialogueRunner;

    
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentDay = DayOfWeek.Tutorial;
        RequestSystem.Instance.InitializeDay();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DayOfWeek GetCurrentDay()
    {
        return currentDay;
    }
  
    public void messageDialouge(string nodename)
    {
        if(activeDialogueRunner != null)
        {
            activeDialogueRunner.Stop();
        }
        activeDialogueRunner = messageAppDialogueRunner;
        activeDialogueRunner.StartDialogue(nodename);
    }
    public void CrystalDialogue(string nodeName)
    {
        if (activeDialogueRunner != null)
        {
            activeDialogueRunner.Stop();
        }
        dialogueBoxDialogueRunner.gameObject.SetActive(true);
        dialogueBoxDialogueRunner.StartDialogue(nodeName);
    }
   
    
}
