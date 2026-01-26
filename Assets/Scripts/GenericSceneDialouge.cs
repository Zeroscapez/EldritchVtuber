using UnityEngine;

public class GenericSceneDialouge : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameStartDialouge();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameStartDialouge()
    {
        DialougeSystem.Instance.StartCoroutine(DialougeSystem.Instance.LoadDialouge("Game Start"));
    }
}
