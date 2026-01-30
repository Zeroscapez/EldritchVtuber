using UnityEngine;

public class StartingSceneControl : MonoBehaviour
{
    private DialougeActivator dialougeActivator;
    public void Awake()
    {
        // Ensure the game runs at normal speed
        Time.timeScale = 1f;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialougeActivator = GetComponent<DialougeActivator>();
        //DialougeSystem.Instance.LoadDialouge("Scene 0");
        DialougeSystem.Instance.playerImage.sprite = DialougeSystem.Instance.EmotionSprites[0];
        DialougeSystem.Instance.PlayerDialougeText.text = "";

    }

  

    
}
