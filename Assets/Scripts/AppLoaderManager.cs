using UnityEngine;

public class AppLoaderManager : MonoBehaviour
{
    public static AppLoaderManager Instance;

    
    public GameObject messagingAppPrefab;

    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMessagingApp()
    {
        messagingAppPrefab.SetActive(true);
    }
}
