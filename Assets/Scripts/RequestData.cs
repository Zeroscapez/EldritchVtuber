using UnityEngine;

[CreateAssetMenu(fileName = "New Request", menuName = "Request System/Request Data")]
public class RequestData : ScriptableObject
{

    public int QuestID;
    public string QuestName;
    public bool IsActive = false;
    [TextArea (3,10)]
    public string Description;
    public int ApprovalAmount;
    public bool IsCompleted = false;

   
}
