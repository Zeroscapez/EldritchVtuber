using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WhacAMoleGame : MonoBehaviour
{
    [Header("UI Screens")]
    public GameObject startScreen;
    public GameObject gameUI;
    public GameObject gameOverScreen;

    [Header("HUD")]
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text finalScoreText;

    [Header("Game References")]
    public RectTransform gameArea;
    public Button molePrefab;
    public RectTransform[] holes;

    [Header("Settings")]
    public float gameTime = 30f;
    public float minShowTime = 0.6f;
    public float maxShowTime = 1.2f;
    public Vector3 moleOffset = new Vector3(0, 20, 0); 

    private Button[] moles;
    private bool gameRunning = false;
    private int score = 0;
    private float timeRemaining;


    void Start()
    {
        startScreen.SetActive(true);
        gameUI.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameUI.SetActive(true);
        gameOverScreen.SetActive(false);

        score = 0;
        timeRemaining = gameTime;
        UpdateScore();
        UpdateTimer();

        if (moles == null || moles.Length == 0)
            CreateMoles();

        gameRunning = true;
        StartCoroutine(MoleRoutine());
        StartCoroutine(TimerRoutine());
    }
    void CreateMoles()
    {
        moles = new Button[holes.Length];

        for (int i = 0; i < holes.Length; i++)
        {
            Button mole = Instantiate(molePrefab, gameArea);
            mole.gameObject.SetActive(false);

            int index = i;
            mole.onClick.AddListener(() => WhackMole(index));

            moles[i] = mole;
        }
    }
    IEnumerator MoleRoutine()
    {
        while (gameRunning)
        {
            int index = Random.Range(0, moles.Length);

            Button mole = moles[index];
            RectTransform hole = holes[index];
            RectTransform rt = mole.GetComponent<RectTransform>();
            rt.position = hole.position + moleOffset;

            mole.gameObject.SetActive(true);

            float showTime = Random.Range(minShowTime, maxShowTime);
            yield return new WaitForSeconds(showTime);

            mole.gameObject.SetActive(false);
        }
    }

    IEnumerator TimerRoutine()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimer();
            yield return null;
        }

        EndGame();
    }

    void WhackMole(int index)
    {
        if (!gameRunning) return;
        if (!moles[index].gameObject.activeSelf) return;

        score++;
        UpdateScore();

        moles[index].gameObject.SetActive(false);
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTimer()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
    }

    void EndGame()
    {
        gameRunning = false;

        foreach (Button mole in moles)
            mole.gameObject.SetActive(false);

        gameOverScreen.SetActive(true);
        gameUI.SetActive(false);
        finalScoreText.text = "Score: " + score;

        Debug.Log("Game Over! Final Score: " + score);
    }
    public void RestartGame()
    {
        StartGame();
    }
}
