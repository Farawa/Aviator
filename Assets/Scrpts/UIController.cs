using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance = null;

    [SerializeField] private BGSwitcher BGSwitcher;
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

        await Task.Delay(1000);

        BGSwitcher.SetBG(BGType.menu);
        if (!PlayerPrefsHelper.IsWelcomBonusGain())
        {
            HideAll();
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

    private void ShowTerms()
    {
        HideAll();
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
