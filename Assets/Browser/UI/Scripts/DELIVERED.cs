using UnityEngine;

public class ShowPanelButton : MonoBehaviour
{
    [Header("Panel to Show")]
    public GameObject panelToShow; // Assign the panel you want to unhide

    // Call this from the Button's OnClick()
    public void ShowPanel()
    {
        if (panelToShow != null)
            panelToShow.SetActive(true);
    }
}
