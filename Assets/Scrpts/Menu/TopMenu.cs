using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsCounter;
    [SerializeField] private Button homeButton;

    private void Start()
    {
        PointsController.OnUpdatePoints += (int value) => { pointsCounter.text = value.ToString(); };
        pointsCounter.text = PointsController.PointsEarned.ToString();
    }

    public void ShowHomeButton()
    {
        homeButton.gameObject.SetActive(true);
        pointsCounter.gameObject.SetActive(false);
    }

    public void ShowPoints()
    {
        homeButton.gameObject.SetActive(false);
        pointsCounter.gameObject.SetActive(true);
    }
}
