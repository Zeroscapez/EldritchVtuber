using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class WordleBoard : MonoBehaviour
{
   

    private WordleRow[] rows;
    [SerializeField] private int rowIndex;
    [SerializeField] private int columnIndex;
    
    [SerializeField] private string targetWord = "APPLE";
    [SerializeField] private string currentGuess = "";
    private int attempts = 0;


    InputAction typeLetter;
    InputAction removeLetter;
    InputAction submitRow;
    private void Awake()
    {
        typeLetter = InputSystem.actions.FindAction("TypeLetter");
        removeLetter = InputSystem.actions.FindAction("RemoveLetter");
        submitRow = InputSystem.actions.FindAction("SubmitRow");
        rows = GetComponentsInChildren<WordleRow>();


    }

    private void OnEnable()
    {
        

    }

    private void OnDisable()
    {
        EndWordle();

    }

    public void Start()
    {
        StartWordle();
    }

    void Update()
    {
        OnLetterTyped();
        OnLetterRemoved();

       
        OnRowSubmit(rows[rowIndex]);
    }

    public void StartWordle() 
    {

        PlayerControlManager.Instance.EnablePlayerControl(false);
        InputSystem.actions.FindActionMap("Wordle").Enable();
    }

    public void EndWordle()
    {
        PlayerControlManager.Instance.EnablePlayerControl(true);
        InputSystem.actions.FindActionMap("Wordle").Disable();
    }


    private void OnLetterTyped()
    {
        if(!typeLetter.WasPressedThisFrame())
        {
           
            return;
        }
        
        Debug.Log("Typeletter pressed");

        if(columnIndex >= rows[rowIndex].tiles.Length)
        {
            Debug.Log("Row full");
            return;
        }


        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            foreach (KeyControl key in Keyboard.current.allKeys)
            {
                if (key.wasPressedThisFrame && key.displayName.Length == 1)
                {
                    char pressedChar = key.displayName[0];
                 

                    if(char.IsLetter(pressedChar))
                    {
                        currentGuess += key.displayName;
                        Debug.Log("Current Guess: " + currentGuess);
                        rows[rowIndex].tiles[columnIndex].SetLetter(pressedChar);
                        columnIndex++;
                    }
                    
                }
            }
        }

    }

    public void OnLetterRemoved()
    {
        if(!removeLetter.WasPressedThisFrame())
        {
            return;
        }

        columnIndex = Mathf.Max(columnIndex - 1, 0);
        rows[rowIndex].tiles[columnIndex].SetLetter('\0');
        
    }

    public void OnRowSubmit(WordleRow row)
    {
        if(!submitRow.WasPressedThisFrame())
        {
            return;
        }

        if(columnIndex < row.tiles.Length)
        {
            Debug.Log("Not enough letters");
            return;
        }
        for (int i = 0; i < row.tiles.Length; i++)
        {
            WordleTile tile = row.tiles[i];

            if(tile.letter == targetWord[i])
            {
                Debug.Log("Correct letter in correct position");
            }
            else if(targetWord.Contains(tile.letter))
            {
                Debug.Log("Correct letter in wrong position");
            }
            else
            {
                Debug.Log("Incorrect letter");
            }

        }

        rowIndex++;
        columnIndex = 0;
        currentGuess = "";
        if (rowIndex >= rows.Length)
        {
            Debug.Log("No more attempts left!");
            // End game logic here
            return;
        }
    }
  

}
