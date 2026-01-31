using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCardsController : MonoBehaviour
{

    [SerializeField] MemoryCard cardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;

    private List<Sprite> spritePairs;

    public GameObject victoryScreen;
    public GameObject memoryGame;

    MemoryCard firstSelected;
    MemoryCard secondSelected;

    int matchCounts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PrepareSprites();
        CreateCards();
        victoryScreen.SetActive(false);
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
            card.controller = this;
        }
    }

    public void SetSelected(MemoryCard card)
    {
        if (card.isSelected == false)
        {
            card.ShowCard();

            if(firstSelected == null)
            {
                firstSelected = card;
                return;
            }

            if(secondSelected == null)
            {
                secondSelected = card;
                StartCoroutine(CheckMatching(firstSelected, secondSelected));
                firstSelected = null;
                secondSelected = null;
            }
        }
    }

    IEnumerator CheckMatching(MemoryCard a, MemoryCard b)
    {
        yield return new WaitForSeconds(0.3f);
        if (a.iconSprite == b.iconSprite)
        {
            // Matched
            matchCounts++;
            if(matchCounts >= spritePairs.Count / 2)
            {
                //game clear
                victoryScreen.SetActive(true);
                StartCoroutine(EndGame());
               
            }
        }
        else
        {
            // Flip them back
            a.HideCard();
            b.HideCard();
        }
    }

    IEnumerator EndGame()
    {
        GameManager.Instance.activeDialogueRunner.StartDialogue("memoryWin");
        yield return new WaitForSeconds(2);
        memoryGame.SetActive(false);
    }

    //Shuffles a list of sprites
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
