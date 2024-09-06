using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWindowController : MonoBehaviour
{
    [SerializeField] private List<Sprite> levelNumber;
    [SerializeField] private Image numberImage;
    [SerializeField] private Button arrowLeft;
    [SerializeField] private Button arrowRight;
    [SerializeField] private Button startGameButton;
    private int currentSelectedLevel = 1;

    private void Start()
    {
        arrowLeft.onClick.AddListener(SelectNextLevel);
        arrowRight.onClick.AddListener(SelectPreviewLevel);
        currentSelectedLevel = ProgressHolder.MaxLevelEarned;
        SelectLevel(currentSelectedLevel);
        startGameButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        UIController.Instance.ShowGame();
    }

    private void SelectLevel(int selectedLevel)
    {
        currentSelectedLevel = selectedLevel;
        ProgressHolder.SelectedLevel = currentSelectedLevel;
        numberImage.sprite = levelNumber[currentSelectedLevel-1];
        CheckArrowsEnabled();
        Debug.Log($"selected {currentSelectedLevel}");
    }

    private void SelectPreviewLevel()
    {
        currentSelectedLevel++;
        ProgressHolder.SelectedLevel = currentSelectedLevel;
        SelectLevel(currentSelectedLevel);
        CheckArrowsEnabled();
    }

    private void SelectNextLevel()
    {
        currentSelectedLevel--;
        ProgressHolder.SelectedLevel = currentSelectedLevel;
        SelectLevel(currentSelectedLevel);
        CheckArrowsEnabled();
    }

    private void CheckArrowsEnabled()
    {
        arrowLeft.interactable = currentSelectedLevel == 1 ? false : true;
        arrowRight.interactable = currentSelectedLevel == ProgressHolder.MaxLevel ||
            currentSelectedLevel == ProgressHolder.MaxLevelEarned ? false : true;
    }
}
