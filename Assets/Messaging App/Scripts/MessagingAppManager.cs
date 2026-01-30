using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagingAppManager : MonoBehaviour
{
    public static MessagingAppManager Instance;
    public Scrollbar Scrollbar;
    public GameObject MessagePrefab;
    public Transform MessageTransform;
    public List<GameObject> MessageList;


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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void CreateMessage(DialogueLine messageInfo)
    {
       
        GameObject newMessage = Instantiate(MessagePrefab, MessageTransform);
        MessageObjectControl messageText = newMessage.GetComponent<MessageObjectControl>();

        messageText.correspondingLine = messageInfo;
        MessageList.Add(newMessage);
       
    }
}
