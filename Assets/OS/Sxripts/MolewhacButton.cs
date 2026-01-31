using UnityEngine;

public class MolewhacButton : TaskBarButton
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
