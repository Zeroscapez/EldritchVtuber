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
        RequestSystem.Instance.StartCoroutine(RequestSystem.Instance.CompleteSpecificRequest(1));
    }


}
