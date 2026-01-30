using UnityEngine;

public class AppLoaderManager : MonoBehaviour
{
    public GameObject messagingAppPrefab;
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
