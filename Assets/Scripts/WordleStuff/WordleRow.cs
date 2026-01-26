using UnityEngine;

public class WordleRow : MonoBehaviour
{
    public WordleTile[] tiles {get; private set; }


    public void Awake()
    {
        tiles = GetComponentsInChildren<WordleTile>();
    }
   
}
