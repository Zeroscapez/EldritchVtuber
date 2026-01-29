using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCardsController : MonoBehaviour
{

    [SerializeField] MemoryCard cardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;

    private List<Sprite> spritePairs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PrepareSprites();
        CreateCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PrepareSprites()
    {
        spritePairs = new List<Sprite>();
        for (int i = 0; i < sprites.Length; i++)
        {
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }
        ShuffleSprites(spritePairs);
    }

    void CreateCards()
    {
        for (int i = 0; i < spritePairs.Count; i++)
        {
            MemoryCard card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
        }
    }

    void ShuffleSprites(List<Sprite> spriteList)
    {
        for (int i = spriteList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex];
            spriteList[randomIndex] = temp;
        }
    }
}
