using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
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

    public TextMeshProUGUI dayOSTime;
  
    public List<GameObject> highlighters1;
    public List<GameObject> highlighters2;
    public List<GameObject> highlighters3;

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
        ShowOutline2();
        currentDay = DayOfWeek.Tutorial;
        RequestSystem.Instance.InitializeDay(currentDay);
 
       

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


    [YarnCommand("highlight_2")]
    public void ShowOutline2()
    {
        foreach (GameObject go2 in highlighters2)
        {
            if (go2.activeSelf == true)
            {
                go2.SetActive(false);
            }
            else
            {
                go2.SetActive(true);
            }

        }
    }

    [YarnCommand("start_day")]
    public void StartDay(string Day)
    {
        switch (Day)
        {
            case "Day1":
                currentDay = DayOfWeek.Monday;
                dayOSTime.text = "Mon";
                break;
            case "Day2":
                currentDay = DayOfWeek.Tuesday;
                dayOSTime.text = "Tue";
                break;
            case "Day3":
                currentDay = DayOfWeek.Wednesday;
                dayOSTime.text = "Wen";
                break;
            case "default":
                currentDay = DayOfWeek.Tutorial;
                dayOSTime.text = "Sun";
                break;

        }

        RequestSystem.Instance.InitializeDay(currentDay);
        activeDialogueRunner.StartDialogue(Day);

    }



}
