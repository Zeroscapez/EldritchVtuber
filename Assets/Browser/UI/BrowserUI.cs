using UnityEngine;

public class BrowserUI : MonoBehaviour
{
    public static BrowserUI Instance;
    public Transform browserWindow;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenWebsite(GameObject website)
    {
        Instantiate(website, browserWindow);
        website.SetActive(true);
    }


    
}
