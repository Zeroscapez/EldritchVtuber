using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesktopController : MonoBehaviour
{

    public GameObject browser;
    public List<GameObject> apps;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       


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
