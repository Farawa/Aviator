using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWindowController : MonoBehaviour
{
    [SerializeField] private List<Sprite> levelNumber;
    [SerializeField] private Image numberImage;
    [SerializeField] private Button arrowLeft;
    [SerializeField] private Button arrowRight;
    private int currentSelectedLevel = 1;

    private void Start()
    {
        arrowLeft.onClick.AddListener(SelectNextLevel);
        arrowRight.onClick.AddListener(SelectPreviewLevel);
        currentSelectedLevel = ProgressHolder.MaxLevelEarned;
        SelectLevel(currentSelectedLevel);
    }

    private void SelectLevel(int selectedLevel)
    {
        currentSelectedLevel = selectedLevel;
        CheckArrowsEnabled();
    }

    private void SelectPreviewLevel()
    {
        CheckArrowsEnabled();
    }

    private void SelectNextLevel()
    {
        CheckArrowsEnabled();
    }

    private void CheckArrowsEnabled()
    {
        arrowLeft.enabled = currentSelectedLevel == 1 ? false : true;
        arrowRight.enabled = currentSelectedLevel == ProgressHolder.MaxLevel ||
            currentSelectedLevel == ProgressHolder.MaxLevelEarned ? false : true;
    }
}
