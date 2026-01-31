using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public enum DayOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
    Tutorial
}
public class RequestSystem : MonoBehaviour
{
    public static RequestSystem Instance;
    public TextMeshProUGUI requestNameText;
    public RequestLogic CurrentRequest;
    public List<RequestLogic> AvailableRequests = new List<RequestLogic>();
    public List<RequestLogic> AvailableRequestsMonday = new List<RequestLogic>();
    public List<RequestLogic> AvailableRequestsTuesday = new List<RequestLogic>();
    public List<RequestLogic> AvailableRequestsWednesday = new List<RequestLogic>();
    public List<RequestLogic> AvailbleRequestTutorial = new List<RequestLogic>();

    [Header("Request Parents")]
    public GameObject TutorialRequestParent;
    public GameObject Day1RequestParent;
    public GameObject Day2RequestParent;
    public GameObject Day3RequestParent;


    public bool isRequestActive = false;
    public int currentApprovalRating = 0;
    public int requestIndex = 0;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }
     

    }

    public void OnDestroy()
    {
       
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void InitializeDay(DayOfWeek today)
    {
        SetDayList(today);
        
    }

    
    public void StartRequest(int i) //Debug purposes, can select which request to start
    {
        CurrentRequest = AvailableRequests[i];
        requestNameText.text = CurrentRequest.refRequest.QuestName;
        CurrentRequest.refRequest.IsCompleted = false;
        CurrentRequest.refRequest.IsActive = true;
    }

    [YarnCommand("next_request")]
    public void NextRequest()
    {
       

        if (AvailableRequests.Count > 0)
        {
            requestIndex++;
            CurrentRequest = AvailableRequests[requestIndex];
           
        }
        else
        {
            CurrentRequest = null;
            requestNameText.text = "No More Requests Today";
        }
        
    }

    [YarnCommand("start_request")]
    public void SetRequest(int requestID)
    {
        
        CurrentRequest = AvailableRequests.Find(a  => a.RequestID == requestID);
        requestNameText.text = CurrentRequest.refRequest.QuestName;
        CurrentRequest.isCompleted = false;
        CurrentRequest.isRequestActive = true;
        isRequestActive = true;
    }
   

    [YarnCommand("complete_request")]
    public void CompleteRequest(int requestID)
    {
        if (CurrentRequest == null)
        {
            Debug.LogWarning("REQUEST MISSING");
            return;
        }

        if (isRequestActive == true)
        {
            CurrentRequest = AvailableRequests.Find(a => a.RequestID == requestID);
          
            CurrentRequest.isCompleted = true;
            CurrentRequest.isRequestActive = false;
            currentApprovalRating += CurrentRequest.refRequest.ApprovalAmount;

            StreamOverlayUIControl.OnApprovalChange?.Invoke();

            isRequestActive = false;
            CurrentRequest = null;


        }
    }

    public void CompleteRequest()
    {
        if (CurrentRequest == null)
        {
            Debug.LogWarning("REQUEST MISSING");
            return;
        }

        if (isRequestActive == true)
        {
            
     
            CurrentRequest.isCompleted = true;
            CurrentRequest.isRequestActive = false;
            currentApprovalRating += CurrentRequest.refRequest.ApprovalAmount;

            StreamOverlayUIControl.OnApprovalChange?.Invoke();

            isRequestActive = false;
            CurrentRequest = null;

            NextRequest();
        }
    }

    [YarnCommand("check_request")]
    public void CheckForRequest()
    {
        if (CurrentRequest == null)
        {
            if(AvailableRequests.Count > 0)
            {
                CurrentRequest = AvailableRequests[0];
            }
            else
            {
                CurrentRequest = null;
                requestNameText.text = "No More Requests Today";
            }
        }
    }

    public IEnumerator CompleteSpecificRequest(int index)
    {
       if (AvailableRequests.Count <= index)
        {
            yield break;
        }
        RequestLogic specificRequest = AvailableRequests[index];
        if (specificRequest.refRequest == false)
        {
            
    
            specificRequest.refRequest.IsCompleted = true;
            specificRequest.refRequest.IsActive = false;
            currentApprovalRating += specificRequest.refRequest.ApprovalAmount;
            StreamOverlayUIControl.OnApprovalChange?.Invoke();
            AvailableRequests.Remove(specificRequest);
            isRequestActive = false;
            yield return new WaitForSeconds(2f);
            NextRequest();
        }
    }

    public void SetDayList(DayOfWeek today)
    {
        AvailableRequests.Clear();
        switch (today)
        {
            case DayOfWeek.Tutorial:
                foreach(Transform c in TutorialRequestParent.transform)
                {
                    RequestLogic request;

                    request = c.GetComponent<RequestLogic>();

                    AvailableRequests.Add(request);
                }
                break;
            case DayOfWeek.Monday:
                foreach (Transform c in Day1RequestParent.transform)
                {
                    RequestLogic request;

                    request = c.GetComponent<RequestLogic>();

                    AvailableRequests.Add(request);
                }
                break;

            case DayOfWeek.Tuesday:
                AvailableRequests = AvailableRequestsTuesday;
                break;

            case DayOfWeek.Wednesday:
                AvailableRequests = AvailableRequestsWednesday;
                break;
        }

        requestNameText.text = "No More Requests Today";
    }

}
