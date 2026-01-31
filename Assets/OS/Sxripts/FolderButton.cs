using UnityEngine;

public class FolderButton : TaskBarButton
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
                    if (RequestSystem.Instance.CurrentRequest.RequestID == 12)
                    {
                        Debug.Log(RequestSystem.Instance.CurrentRequest.name + "is completed");
                        GameManager.Instance.activeDialogueRunner.StartDialogue("TutorialSection3");
                    }

                }



            }
            else
            {
                connectedApp.SetActive(false);

                if (RequestSystem.Instance.CurrentRequest.RequestID == 12)
                {
                    Debug.Log(RequestSystem.Instance.CurrentRequest.name + "is completed");
                    RequestSystem.Instance.CompleteRequest(12);
                    GameManager.Instance.activeDialogueRunner.StartDialogue("TutorialSection4");
                }
            }
        }
    }
}
