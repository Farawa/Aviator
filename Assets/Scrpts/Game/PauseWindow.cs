using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button homeButton;

    private void Start()
    {
        resumeButton.onClick.AddListener(() => GameManager.instance.ResumeGame());
        resetButton.onClick.AddListener(() => GameManager.instance.ResetGame());
        homeButton.onClick.AddListener(() => UIController.Instance.ShowMenu());
    }
}
