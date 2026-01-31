using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public Button exitButton;
    public Button optionsButton;
    public GameObject optionsMenu;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exitButton.onClick.AddListener(GoTitle);
        optionsButton.onClick.AddListener(OpenOptions);
    }

    

    public void GoTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void OpenOptions()
    {
        if (optionsMenu != null)
        {
            if (optionsMenu.activeSelf == false)
            {
                optionsMenu.SetActive(true);


            }
            else
            {
                optionsMenu.SetActive(false);
            }


        }
    }
}
