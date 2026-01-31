using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private DayOfWeek currentDay;

    [Header("Dialogue")]
    public DialogueRunner activeDialogueRunner;

    [Header("Audio")]
    public AudioManager audioManager;
  
    public List<GameObject> highlighters1;
    
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowOutline1();
        currentDay = DayOfWeek.Tutorial;
        RequestSystem.Instance.InitializeDay();
 
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DayOfWeek GetCurrentDay()
    {
        return currentDay;
    }

    [YarnCommand("highlight_1")]
    public void ShowOutline1()
    {
        foreach (GameObject go2 in highlighters1)
        {
            if(go2.activeSelf == true)
            {
                go2.SetActive(false);
            }
            else
            {
                go2.SetActive(true);
            }
            
        }
    }
  
   
    
}
