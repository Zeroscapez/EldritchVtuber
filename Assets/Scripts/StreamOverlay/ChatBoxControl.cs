using TMPro;
using UnityEngine;

public class ChatBoxControl : MonoBehaviour
{
    public TextMeshProUGUI chatMessage;
    public TextMeshProUGUI chatterName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText(string name, string text)
    {
        chatterName.text = name + ":";
        chatMessage.text = text;
       
    }
}
