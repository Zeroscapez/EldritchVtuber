using UnityEngine;

public class AppLoaderManager : MonoBehaviour
{
    public static AppLoaderManager Instance;

    
    public GameObject messagingAppPrefab;
    public GameObject wordify;
    public GameObject whacmolegame;
    public GameObject memoryGame;

    public GameObject apploader;

    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        apploader = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseAllApps()
    {
        foreach(Transform transform in apploader.transform)
        {
           transform.gameObject.SetActive(false);
        }
    }

    public void OpenMessagingApp()
    {
        messagingAppPrefab.SetActive(true);
    }
}
