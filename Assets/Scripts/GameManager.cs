using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private DayOfWeek currentDay;

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
}
