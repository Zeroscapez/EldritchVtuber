using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WordleBoard : MonoBehaviour
{
   

    private WordleRow[] rows;

    private string[] solutions;
    private string[] validWords;


    [SerializeField] private int rowIndex;
    [SerializeField] private int columnIndex;
    
    private string targetWord = "APPLE";
    [SerializeField] private string currentGuess = "";
    private int attempts = 0;


    [Header("States")]
    public WordleTile.State emptyState;
    public WordleTile.State occupiedState;
    public WordleTile.State correctState;
    public WordleTile.State wrongSpotState;
    public WordleTile.State incorrectState;

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
       TextAsset textfile = Resources.Load("official_wordle_all") as TextAsset;
       validWords = textfile.text.Split('\n');

        textfile = Resources.Load("official_wordle_common") as TextAsset;
        solutions = textfile.text.Split('\n');

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
        SetRandomWord();
        PlayerControlManager.Instance.EnablePlayerControl(false);
        InputSystem.actions.FindActionMap("Wordle").Enable();
        
    }

    public void EndWordle()
    {
        PlayerControlManager.Instance.EnablePlayerControl(true);
        InputSystem.actions.FindActionMap("Wordle").Disable();
    }

    private void SetRandomWord()
    {
        targetWord = solutions[Random.Range(0, solutions.Length)];
        targetWord = targetWord.ToLower().Trim();
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
                    char pressedChar = key.displayName.ToLower()[0];
                 

                    if(char.IsLetter(pressedChar))
                    {
                      
                        rows[rowIndex].tiles[columnIndex].SetLetter(pressedChar);
                        rows[rowIndex].tiles[columnIndex].SetState(emptyState);
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
        rows[rowIndex].tiles[columnIndex].SetState(emptyState);


    }

    public void OnRowSubmit(WordleRow row)
    {

        
        if(!submitRow.WasPressedThisFrame())
        {
            return;
        }

        if (!IsValidWord(row.word))
        {
            Debug.Log("Not a valid word!");
            return;
        }
        string remaining = targetWord;


        for(int i = 0; i < row.tiles.Length; i++)
        {
            WordleTile tile = row.tiles[i];

            if(tile.letter == targetWord[i])
            {
                tile.SetState(correctState);

                remaining = remaining.Remove(i, 1);
                remaining = remaining.Insert(i, " ");
            }
            else if (!targetWord.Contains(tile.letter))
            {
                tile.SetState(incorrectState);
            }
        }

        for(int i = 0; i < row.tiles.Length; i++)
        {
            WordleTile tile = row.tiles[i];

            if(tile.state != correctState && tile.state != incorrectState)
            {
               if(remaining.Contains(tile.letter))
                {
                    tile.SetState(wrongSpotState);

                    int index = remaining.IndexOf(tile.letter);
                    remaining = remaining.Remove(i, 1).Insert(i, " ");
                }
                else
                {
                    tile.SetState(incorrectState);
                }
            }
        }

        rowIndex++;
        columnIndex = 0;

        if (rowIndex >= rows.Length)
        {
            Debug.Log("No more attempts left!");
            // End game logic here
            return;
        }
    }
  

    private bool IsValidWord(string word)
    {
        for (int i = 0; i < validWords.Length; i++)
        {
            if(validWords[i] == word)
            {
                return true;
            }
        }
        return false;
    }
}
