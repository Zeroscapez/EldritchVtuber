using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public bool isRequestActive = false;
    public int currentApprovalRating = 0;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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

    public void InitializeDay()
    {
        SetDayList(GameManager.Instance.GetCurrentDay());
        SetRequest();
    }

    public void StartRequest(int i) //Debug purposes, can select which request to start
    {
        CurrentRequest = AvailableRequests[i];
        requestNameText.text = CurrentRequest.refRequest.QuestName;
        CurrentRequest.refRequest.IsCompleted = false;
        CurrentRequest.refRequest.IsActive = true;
    }

    public void NextRequest()
    {
        AvailableRequests.Remove(CurrentRequest);
        if (AvailableRequests.Count > 0)
        {
            SetRequest();
           
        }
        else
        {
            CurrentRequest = null;
            requestNameText.text = "No More Requests Today";
        }
        
    }

    public void SetRequest()
    {
        
        CurrentRequest = AvailableRequests[0];
        requestNameText.text = CurrentRequest.refRequest.QuestName;
        CurrentRequest.refRequest.IsCompleted = false;
        CurrentRequest.refRequest.IsActive = true;
        isRequestActive = true;
    }

    public IEnumerator CompleteRequest()
    {
        if (CurrentRequest == null)
        {
            yield break;
        }

        if (isRequestActive == true)
        { 
        CurrentRequest.refRequest.IsCompleted = true;
            CurrentRequest.refRequest.IsActive = false;
            currentApprovalRating += CurrentRequest.refRequest.ApprovalAmount;

            StreamOverlayUIControl.OnApprovalChange?.Invoke();
        AvailableRequests.Remove(CurrentRequest);
        isRequestActive = false;
        yield return new WaitForSeconds(2f);
        NextRequest();
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
            Debug.Log("Completing Specific Request: " + specificRequest.refRequest);
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
        switch (today)
        {
            case DayOfWeek.Tutorial:
                AvailableRequests = AvailbleRequestTutorial;
                break;
            case DayOfWeek.Monday:
                AvailableRequests = AvailableRequestsMonday;
                break;

            case DayOfWeek.Tuesday:
                AvailableRequests = AvailableRequestsTuesday;
                break;

            case DayOfWeek.Wednesday:
                AvailableRequests = AvailableRequestsWednesday;
                break;
        }
    }

}
