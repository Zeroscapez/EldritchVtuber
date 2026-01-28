using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button buttonref;

    void Start()
    {
        buttonref = GetComponent<Button>();
        buttonref.onClick.AddListener(OnStartButtonClicked);
    }


    private void OnStartButtonClicked()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        Debug.Log("Start Button Clicked - Load MainScene");
    }
}
