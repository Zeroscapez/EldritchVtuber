using UnityEngine;
using UnityEngine.UI;

public class HyperLinkController : MonoBehaviour
{
    private Button buttonRef;
    public GameObject websiteObject;
    

    public void Awake()
    {
        buttonRef = GetComponent<Button>();
        buttonRef.onClick.AddListener(OpenLink);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLink()
    {
      BrowserUI.Instance.OpenWebsite(websiteObject);

    }
}
