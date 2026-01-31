using UnityEngine;

public class WordleRow : MonoBehaviour
{
    public WordleTile[] tiles {get; private set; }

    public string word
    {
        get
        {
            string word = "";

            for (int i = 0; i < tiles.Length; i++)
            {
                word += tiles[i].letter;
            }

          
            return word.ToLower();
        }
    }

    public void Awake()
    {
        tiles = GetComponentsInChildren<WordleTile>();
    }
   
}
