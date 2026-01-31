using UnityEngine;

public class MemoryGameButton : TaskBarButton
{
    public override void OpenApp()
    {
        base.OpenApp();
        if (connectedApp != null)
        {
            if (connectedApp.activeSelf == false)
            {
                connectedApp.SetActive(true);


            }
            else
            {
                connectedApp.SetActive(false);
            }


        }
    }
}
