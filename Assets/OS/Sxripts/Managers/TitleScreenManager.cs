using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.PlayTitleMusic();
        AudioManager.Instance.SFX.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
