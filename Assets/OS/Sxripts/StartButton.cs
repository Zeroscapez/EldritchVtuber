using UnityEngine;
using UnityEngine.UI;

public class StartButton : TaskBarButton
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
