using NUnit.Framework.Constraints;
using UnityEngine;
using Yarn.Unity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Refs")]
    public AudioSource BGM;
    public AudioSource SFX;

    [Header("BGM-Sounds")]
    public AudioClip TitleBGM;
    public AudioClip MainBGM;

    [Header("SFX-Sounds")]
    public AudioClip notification;
    public AudioClip cheer;
    public AudioClip crunchSFX;
    public AudioClip screamSFX;


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
        BGM.volume = 0.3f;
        SFX.volume = 0.7f;
        PlayTitleMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM()
    {
        BGM.clip = MainBGM;
        BGM.Play();
    }

    public void PlayTitleMusic()
    {
        BGM.clip = TitleBGM;
        BGM.Play();
    }

    public void PlayNotificationSound()
    {
        SFX.clip = notification;
        SFX.Play();
    }

    [YarnCommand("cheer")]
    public void PlayCheer()
    {
        SFX.clip = cheer;
        SFX.Play();
    }

    [YarnCommand("crunch")]
    public void PlayCrunch()
    {
        SFX.clip = crunchSFX;
        SFX.Play();

    }

}
