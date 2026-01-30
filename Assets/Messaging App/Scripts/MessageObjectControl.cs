using TMPro;
using UnityEngine;

public class MessageObjectControl : MonoBehaviour
{

    public TextMeshProUGUI messageText;
    public TextMeshProUGUI messageSender;
    

    private void OnEnable()
    {
   
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // messageSender.text = correspondingLine.Actor.ToString();
       // messageText.text = correspondingLine.Line.ToString();
    }

    public void ShowText(string sender, string text)
    {
        messageSender.text = sender;
        messageText.text = text;
    }


  

}
