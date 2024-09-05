using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance = null;

    [SerializeField] private TopMenu topMenu;
    [SerializeField] private GameObject mainMenuWindow;
    [SerializeField] private GameObject levelSelectWindow;
    [SerializeField] private GameObject statsWindow;
    [SerializeField] private Button showLevelsButton;
    [SerializeField] private Button showStatsButton;

    private void Awake()
    {
        if (!Instance) Instance = this;
        else Debug.LogError("MTOI");
    }

    private void Start()
    {
        ResetMenu();
        showLevelsButton.onClick.AddListener(ShowLevelSelect);
        showStatsButton.onClick.AddListener(ShowStats);
    }

    public void ShowStats()
    {
        topMenu.ShowHomeButton();
        mainMenuWindow.SetActive(false);
        statsWindow.SetActive(true);
    }

    public void ShowLevelSelect()
    {
        topMenu.ShowHomeButton();
        mainMenuWindow.SetActive(false);
        levelSelectWindow.SetActive(true);
    }

    internal void ResetMenu()
    {
        topMenu.ShowPoints();
        levelSelectWindow.SetActive(false);
        statsWindow.SetActive(false);
        mainMenuWindow.SetActive(true);
    }
}
