using System;
using UnityEngine;
using UnityEngine.UI;

public class StreamOverlayUIControl : MonoBehaviour
{

    public Slider approvalAmount;
    public Image playerImage;
    public Sprite[] EmotionSprites;
    public static Action OnApprovalChange;


    public void Awake()
    {
        OnApprovalChange += UpdateApproval;
     
    }

    public void OnDestroy()
    {
        OnApprovalChange -= UpdateApproval;
     
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeUI()
    {
        UpdateApproval();
    }

    public void UpdateApproval()
    {
        approvalAmount.value = RequestSystem.Instance.currentApprovalRating;
    }

}
