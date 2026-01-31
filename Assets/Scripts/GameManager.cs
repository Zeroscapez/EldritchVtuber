using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private DayOfWeek currentDay;

    [Header("Dialogue")]
    public GameObject bloodbox;
    public GameObject narratorScreen;
    public DialogueRunner activeDialogueRunner;
    public DialogueRunner NarratorDialogueRunner;
    public DialogueRunner chatDialogueRunner;

    [Header("Audio")]
    public AudioManager audioManager;

    public TextMeshProUGUI dayOSTime;
  
    public List<GameObject> highlighters1;
    public List<GameObject> highlighters2;
    public List<GameObject> highlighters3;

    [Header("AppIcons")]
    public CanvasGroup taskbarIcons;
    public CanvasGroup desktopIcons;
    public List<GameObject> WhacMoleObjects;
    public List<GameObject> wordifyObjects;
    public List<GameObject> memoryGameObjects;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
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
        ShowOutline3();
        currentDay = DayOfWeek.Tutorial;
        RequestSystem.Instance.InitializeDay(currentDay);
        taskbarIcons.interactable = false;
        desktopIcons.interactable = false;
        audioManager = AudioManager.Instance;
        audioManager.PlayBGM();
       
 
       

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


    [YarnCommand("highlight_3")]
    public void ShowOutline3()
    {
        foreach (GameObject go2 in highlighters3)
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

    [YarnCommand("show_wordify")]
    public void showWordify()
    {
        AppLoaderManager.Instance.wordify.gameObject.SetActive(true);
        //foreach (GameObject go2 in wordifyObjects)
        //{
        //    go2.SetActive(true);
        //}
    }

    [YarnCommand("show_wacmole")]
    public void showWacmole()
    {
       AppLoaderManager.Instance.whacmolegame.gameObject.SetActive(true);
        //foreach (GameObject go2 in WhacMoleObjects)
        //{
        //    go2.SetActive(true);
        //}
    }

    [YarnCommand("show_memory")]
    public void showMemory()
    {
        AppLoaderManager.Instance.memoryGame.gameObject.SetActive(true);
        //foreach (GameObject go2 in memoryGameObjects)
        //{
        //    go2.SetActive(true);
        //}
    }

    [YarnCommand("caninteract")]
    public void allowOSInteract(bool allowOSInteract)
    {
        taskbarIcons.interactable = allowOSInteract;
        desktopIcons.interactable = allowOSInteract;
    }

    [YarnCommand("narrationscreen")]
    public void narrationScreenOn()
    {
        narratorScreen.SetActive(true);
    }

    [YarnCommand("setbloodbox")]
    public void activateBloodBox()
    {
        bloodbox.SetActive(true);
    }

    [YarnCommand("endgame")]
    public void EndGame()
    {
        SceneManager.LoadScene("TitleScreen");
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

    [YarnCommand("chat_response")]
    public void chat(string nodeName)
    {
        chatDialogueRunner.StartDialogue(nodeName);
    }

   


}
