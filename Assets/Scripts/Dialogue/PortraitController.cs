using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class PortraitController : MonoBehaviour
{
    public Sprite[] EmotionSprites;
    public Image characterImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Awake()
    {
       // characterImage = GetComponent<Image>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [YarnCommand("emotion")]
    public void ChangePortrait(string emotion)
    {
      
        switch (emotion)
        {
            case "neutral":
                characterImage.sprite = EmotionSprites[0];
                  break;
            case "joy":
                characterImage.sprite = EmotionSprites[1];
                break;
            case "fear":
                characterImage.sprite = EmotionSprites[2];
                break;
            case "smug":
                characterImage.sprite = EmotionSprites[3];
                break;
            case "pout": 
                characterImage.sprite= EmotionSprites[4];
                break;
            case "cry":
                characterImage.sprite = EmotionSprites[5];
                break;
            case "confused":
                characterImage.sprite = EmotionSprites[6];
                break;
            case "nervous":
                characterImage.sprite = EmotionSprites[7];
                break;
             default:
                Debug.Log("Not Valid Emotion");
                break;
                
        }


   
    }
}
