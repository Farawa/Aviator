using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance = null;

    [SerializeField] private TopMenu topMenu;
    [SerializeField] private GameObject levelSelectWindow;
    [SerializeField] private GameObject statsWindow;

    private void Start()
    {
        ResetMenu();
    }

    public void ShowStats()
    {
        statsWindow.SetActive(true);
    }

    public void ShowLevelSelect()
    {
        levelSelectWindow.SetActive(true);
    }

    internal void ResetMenu()
    {
        topMenu.ShowPoints();
        levelSelectWindow.SetActive(false);
        statsWindow.SetActive(false);
    }
}
