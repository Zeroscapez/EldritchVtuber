using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class PlayerControlManager : MonoBehaviour
{
    public static PlayerControlManager Instance;
    InputAction textAdvanceAction;
    private DialougeSystem dialougeSystem;
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
        dialougeSystem = DialougeSystem.Instance;
        textAdvanceAction = InputSystem.actions.FindAction("AdvanceText");
        inputSystemUIInputModule = this.GetComponent<InputSystemUIInputModule>();


    }

    // Update is called once per frame
    void Update()
    {
        if (textAdvanceAction.WasPressedThisFrame() && dialougeSystem.AutoAdvance == false)
        {
            
            dialougeSystem.NextLine();
        }
    }

    public void EnablePlayerControl(bool active)
    {
        playerControlEnabled = active;
        inputSystemUIInputModule.enabled = active;
    }
}
