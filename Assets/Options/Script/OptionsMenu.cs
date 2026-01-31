using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

// Simple global volume value accessible from any script
public static class GlobalVolume
{
    public static float Value = 1f; 
}

public class OptionsMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject optionsMenu;   
    public Slider volumeSlider;      
    public Button closeButton;       

    private bool isOpen;

    void Start()
    {
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;

        volumeSlider.value = GlobalVolume.Value;

        if (closeButton != null)
            closeButton.onClick.AddListener(CloseMenu);
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        isOpen = !isOpen;
        optionsMenu.SetActive(isOpen);
        Time.timeScale = isOpen ? 0f : 1f;

        Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isOpen;

        if (isOpen)
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        else
            volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float value)
    {
        GlobalVolume.Value = value;
        AudioListener.volume = value; 
    }

    public void CloseMenu()
    {
        isOpen = false;
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }
}
