using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance = null;

    [SerializeField] private BGSwitcher BGSwitcher;
    [Space]
    [SerializeField] private GameObject plane;
    [SerializeField] private WelcomeBonusWindow welcomeBonusWindow;
    [SerializeField] private PrivacyWindow privacyWindow;
    [SerializeField] private MenuController menuController;
    [SerializeField] private GameObject settings;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("MTOI");
    }

    private async void Start()
    {
        BGSwitcher.SetBG(BGType.preview);
        HideAll();
        plane.SetActive(true);

        await Task.Delay(1000);

        BGSwitcher.SetBG(BGType.menu);
        if (!PlayerPrefsHelper.IsWelcomBonusGain())
        {
            welcomeBonusWindow.gameObject.SetActive(true);
            welcomeBonusWindow.RandomizeBunus();
        }
        else
        {
            ShowMenu();
        }
    }

    internal void OpenSettings()
    {
        settings.SetActive(true);
    }

    private void ShowMenu()
    {
        HideAll();
        menuController.gameObject.SetActive(true);
        MusicController.Instance.StartMenuMusic();
    }

    internal void SetTermsGained()
    {
        HideAll();
        ShowMenu();
    }

    internal void SetBonusGained()
    {
        PlayerPrefsHelper.SetWelcomBonusGain();
        HideAll();
        ShowTerms();
    }

    private void ShowTerms()
    {
        privacyWindow.gameObject.SetActive(true);
    }

    public void ShowGame()
    {
        MusicController.Instance.StartGameMusic();
    }

    private void HideAll()
    {
        plane.SetActive(false);
        welcomeBonusWindow.gameObject.SetActive(false);
        privacyWindow.gameObject.SetActive(false);
        menuController.ResetMenu();
        menuController.gameObject.SetActive(false);
        settings.SetActive(false);
    }

    public void HideSettings()
    {
        settings.SetActive(false);
    }
}
