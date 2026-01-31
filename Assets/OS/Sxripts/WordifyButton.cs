using UnityEngine;

public class WordifyButton : TaskBarButton
{
    public override void OpenApp()
    {
       
        if (connectedApp != null)
        {

            if (connectedApp.activeSelf == false)
            {
                base.OpenApp();
                connectedApp.SetActive(true);


            }
            else
            {
                connectedApp.SetActive(false);
            }


        }
    }
}
