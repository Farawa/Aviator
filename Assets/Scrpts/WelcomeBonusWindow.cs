using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeBonusWindow : MonoBehaviour
{
    [SerializeField] private List<Sprite> bonusNumbers;
    [SerializeField] private Image bonusImage;
    [SerializeField] private Button getButton;
    [SerializeField] private TextMeshProUGUI topLabel;
    private string yourBonusText = "Your bonus";

    public void RandomizeBunus()
    {
        getButton.gameObject.SetActive(false);
        StartCoroutine(RandomBonusCoroutine());
        getButton.onClick.AddListener(GetBonus);
    }

    private void GetBonus()
    {
        UIController.Instance.SetBonusGained();
    }

    private IEnumerator RandomBonusCoroutine()
    {
        var rollTime = Random.Range(2f, 3f);
        var startTime = Time.realtimeSinceStartup;
        int currentIndex = 0;
        while (startTime + rollTime > Time.realtimeSinceStartup)
        {
            currentIndex++;
            if (currentIndex > bonusNumbers.Count - 1) currentIndex = 0;
            bonusImage.sprite = bonusNumbers[currentIndex];
            yield return new WaitForSeconds(0.1f);
        }
        ShowYourBunus();
    }

    private void ShowYourBunus()
    {
        topLabel.text = yourBonusText;
        getButton.gameObject.SetActive(true);
    }
}
