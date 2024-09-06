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
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("MTOI");
    }

    private async void Start()
    {
        Application.targetFrameRate = 60;
        BGSwitcher.SetBG(BGType.preview);
        HideAll();
        plane.SetActive(true);

        await Task.Delay(1000);

        BGSwitcher.SetBG(BGType.menu);
        if (!PlayerPrefsHelper.IsWelcomBonusGain())
        {
            HideAll();
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

    public void ShowMenu()
    {
        HideAll();
        BGSwitcher.SetBG(BGType.menu);
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
        HideAll();
        privacyWindow.gameObject.SetActive(true);
    }

    public void ShowGame()
    {
        HideAll();
        BGSwitcher.SetBG(BGType.game);
        gameManager.gameObject.SetActive(true);
        gameManager.StartGame();
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
        gameManager.gameObject.SetActive(false);
    }

    public void HideSettings()
    {
        settings.SetActive(false);
    }
}
