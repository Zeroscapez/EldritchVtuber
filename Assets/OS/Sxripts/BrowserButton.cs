using UnityEngine;

public class BrowserButton : TaskBarButton
{
   
    public override void OpenApp()
    {
      
        if (connectedApp != null)
        {
            if (connectedApp.activeSelf == false)
            {
                connectedApp.SetActive(true);

                if (RequestSystem.Instance.CurrentRequest != null)
                {
                    if (RequestSystem.Instance.CurrentRequest.RequestID == 11)
                    {
                       
                        RequestSystem.Instance.CompleteRequest(11);
                        GameManager.Instance.activeDialogueRunner.StartDialogue("TutorialSection2");
                    }

                }



            }
            else
            {
                connectedApp.SetActive(false);
            }
        }
    }
}
