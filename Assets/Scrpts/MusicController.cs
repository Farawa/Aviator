using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance = null;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private GameObject shootPrefab;
    private static readonly string soundsKey = "isSoundsEnabled";
    private static readonly string musicKey = "isMusicEnabled";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("MTOI");
    }

    private void Start()
    {
        SetMusicVolume(IsMusicEnabled());
    }

    public void StartMenuMusic()
    {
        audioSource.clip = menuMusic;
        audioSource.Play();
    }

    public void StartGameMusic()
    {
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void SetMusicVolume(bool isEnabled)
    {
        Debug.Log($"music turned {isEnabled}");
        PlayerPrefsHelper.SetBool(musicKey, isEnabled);
        audioSource.mute = !isEnabled;
    }

    public static void SetSoundsVolume(bool isEnabled)
    {
        Debug.Log($"sounds turned {isEnabled}");
        PlayerPrefsHelper.SetBool(soundsKey, isEnabled);
    }

    public static bool IsMusicEnabled()
    {
        var isMusicEnable = PlayerPrefsHelper.GetBool(musicKey, true);
        Debug.Log($"music enabled is {isMusicEnable}");
        return isMusicEnable;
    }

    public static bool IsSoundsEnabled()
    {
        var soundsEnable = PlayerPrefsHelper.GetBool(soundsKey, true);
        Debug.Log($"sounds enabled is {soundsEnable}");
        return soundsEnable;
    }

    public void PlayShoot()
    {
        if (!IsSoundsEnabled()) return;
        Instantiate(shootPrefab, transform);
    }
}
