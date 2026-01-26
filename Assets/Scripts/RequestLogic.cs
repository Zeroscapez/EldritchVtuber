using UnityEngine;

public class RequestLogic : MonoBehaviour
{

    public RequestData refRequest;
    public bool isRequestActive = false;
    public bool isCompleted = false;
    public int RequestID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RequestID = refRequest.QuestID;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteRequest()
    {

        isCompleted = true;
        isRequestActive = false;
    }
}
