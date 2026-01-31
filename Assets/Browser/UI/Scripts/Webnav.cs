using UnityEngine;

public class Webnav : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject currentPanel;
    public void GoHome()
    {
        currentPanel.SetActive(false);
        homePanel.SetActive(true);
    }
}
