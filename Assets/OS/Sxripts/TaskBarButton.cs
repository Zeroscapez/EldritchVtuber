using UnityEngine;
using UnityEngine.UI;

public abstract class TaskBarButton : MonoBehaviour
{
    public GameObject connectedApp;
    private Button buttonRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.buttonRef = GetComponent<Button>();
        buttonRef.onClick.AddListener(OpenApp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OpenApp()
    {

        
    }
}
