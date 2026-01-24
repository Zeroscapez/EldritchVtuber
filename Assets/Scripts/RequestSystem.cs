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
    public RequestData CurrentRequest;
    [SerializeField] private List<RequestData> AvailableRequests = new List<RequestData>();
    public List<RequestData> AvailableRequestsMonday = new List<RequestData>();
    public List<RequestData> AvailableRequestsTuesday = new List<RequestData>();
    public List<RequestData> AvailableRequestsWednesday = new List<RequestData>();
    public List<RequestData> AvailbleRequestTutorial = new List<RequestData>();
    public DayOfWeek currentDay;
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
        InputSystem.actions.FindAction("NextRequest").performed += ctx => NextRequest();

    }

    public void OnDestroy()
    {
        InputSystem.actions.FindAction("NextRequest").performed -= ctx => NextRequest();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetDayList(currentDay);
        SetRequest();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartRequest(int i) //Debug purposes, can select which request to start
    {
        CurrentRequest = AvailableRequests[i];
        requestNameText.text = CurrentRequest.QuestName;
        CurrentRequest.IsCompleted = false;
        CurrentRequest.IsActive = true;
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
        requestNameText.text = CurrentRequest.QuestName;
        CurrentRequest.IsCompleted = false;
        CurrentRequest.IsActive = true;
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
        CurrentRequest.IsCompleted = true;
        CurrentRequest.IsActive = false;
        currentApprovalRating += CurrentRequest.ApprovalAmount;

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
        RequestData specificRequest = AvailableRequests[index];
        if (specificRequest.IsCompleted == false)
        {
            Debug.Log("Completing Specific Request: " + specificRequest.QuestName);
            specificRequest.IsCompleted = true;
            specificRequest.IsActive = false;
            currentApprovalRating += specificRequest.ApprovalAmount;
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
