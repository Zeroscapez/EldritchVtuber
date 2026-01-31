using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn;
using Yarn.Unity;

public class MessagingAppManager : MonoBehaviour
{
    public static MessagingAppManager Instance;
    public GameObject MessagePrefab;
    public Transform MessageTransform;
    public List<GameObject> MessageList;
    private DialogueRunner messageAppRunner;
    public GameObject notification;

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

        //messageAppRunner = GameManager.Instance.messageAppDialogueRunner;

        // Subscribe to dialogue completion
        //messageAppRunner.onDialogueComplete.AddListener(OnMessageDialogueComplete);
    }

    public void OnEnable()
    {
        notification.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public IEnumerator LoadMessages()
    {
        yield return new WaitForSeconds(1);

       
    }

    [YarnCommand("notification")]
    public void SendNotification()
    {
        notification.SetActive(true);
    }

    private void OnMessageDialogueComplete()
    {
        //// Unsubscribe to avoid repeated calls
        //messageAppRunner.onDialogueComplete.RemoveListener(OnMessageDialogueComplete);

        //GameManager.Instance.CrystalDialogue("CrystalSpeak");
    }

}
