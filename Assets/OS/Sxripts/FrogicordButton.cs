using UnityEngine;

public class FrogicordButton : TaskBarButton
{
    public override void OpenApp()
    {
       
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
