using UnityEngine;
using UnityEngine.UI;

public class DesktopController : MonoBehaviour
{

    public GameObject browser;
    public GameObject app2;
    public GameObject app3;
    public GameObject app4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        browser = GameObject.FindGameObjectWithTag("browser");


        browser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBrowser()
    {
        browser.SetActive(true);
    }

    public void CloseBrowser()
    {
        browser.SetActive(false);
    }
}
