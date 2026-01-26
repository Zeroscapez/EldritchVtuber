using UnityEngine;
using UnityEngine.UI;

public class TestButtonControl : MonoBehaviour
{
    private Button selfRef;

    public void Awake()
    {
        selfRef = GetComponent<Button>();
        selfRef.onClick.AddListener(OnButtonClicked);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        Debug.Log("Button was clicked!");

        if (GameManager.Instance.GetCurrentDay() == DayOfWeek.Tutorial)
        {
            StartTutorialScene1();
        }
    }

    public void StartTutorialScene1()
    {
       

        if (RequestSystem.Instance.CurrentRequest != null && RequestSystem.Instance.CurrentRequest.RequestID == 0 )
        {
            Debug
                .Log("Completing Tutorial Request");
            RequestSystem.Instance.StartCoroutine(RequestSystem.Instance.CompleteRequest());
        }

        DialougeSystem.Instance.LoadDialouge("Tutorial Scene 1");
        

    }
}
