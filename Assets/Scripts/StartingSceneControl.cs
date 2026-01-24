using UnityEngine;

public class StartingSceneControl : MonoBehaviour
{
    private DialougeActivator dialougeActivator;
    public void Awake()
    {
        // Ensure the game runs at normal speed
        Time.timeScale = 1f;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialougeActivator = GetComponent<DialougeActivator>();
        dialougeActivator.ActivateDialouge();
        RequestSystem.Instance.currentDay = DayOfWeek.Tutorial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
