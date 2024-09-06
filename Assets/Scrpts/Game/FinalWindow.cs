using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Button next;
    [SerializeField] private Button reset;
    [SerializeField] private Button home;

    private void Start()
    {
        next.onClick.AddListener(SetNextLevel);
        reset.onClick.AddListener(ResetLevel);
        home.onClick.AddListener(UIController.Instance.ShowMenu);
    }

    private void ResetLevel()
    {
        GameManager.instance.ResetGame(true);
    }

    private void SetNextLevel()
    {
        ProgressHolder.SelectedLevel++;
        ResetLevel();
    }

    public void SetScrore(int score)
    {
        this.score.text = $"SCORE\n{score}";
    }
}
