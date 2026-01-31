using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class PlayerControlManager : MonoBehaviour
{
    public static PlayerControlManager Instance;
    InputAction textAdvanceAction;

    public InputSystemUIInputModule inputSystemUIInputModule;
    public bool playerControlEnabled = true;

    private void Awake()
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
       
        textAdvanceAction = InputSystem.actions.FindAction("AdvanceText");
        inputSystemUIInputModule = this.GetComponent<InputSystemUIInputModule>();


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void EnablePlayerControl(bool active)
    {
        playerControlEnabled = active;

        if(inputSystemUIInputModule != null)
        {
            inputSystemUIInputModule.enabled = active;
        }
        
    }

    public void EnablePlayerClick(bool active)
    {
        inputSystemUIInputModule.enabled = active;
    }
}
