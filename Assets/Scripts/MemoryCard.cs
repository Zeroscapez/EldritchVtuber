using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MemoryCard : MonoBehaviour
{

    [SerializeField] private Image iconImage;

    public Sprite iconSprite;
    public Sprite hiddenIconSprite;

    public bool isSelected;

    public MemoryCardsController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCardClick()
    {
        controller.SetSelected(this);
    }

    public void SetIconSprite(Sprite sp)
    {
        iconSprite = sp;
    }

    public void ShowCard()
    {
        iconImage.sprite = iconSprite;
        isSelected = true;
    }

    public void HideCard()
    {
        iconImage.sprite = hiddenIconSprite;
        isSelected = false;
    }
}
