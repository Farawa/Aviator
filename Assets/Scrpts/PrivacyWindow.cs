using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivacyWindow : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Toggle privacy;
    [SerializeField] private Toggle terms;

    private void Start()
    {
        continueButton.interactable = false;
        privacy.isOn = false;
        terms.isOn = false;
        privacy.onValueChanged.AddListener(CheckToggles);
        continueButton.onClick.AddListener(PrivacyContinue);
    }

    private void PrivacyContinue()
    {
        UIController.Instance.SetTermsGained();
    }

    private void CheckToggles(bool arg0)
    {
        continueButton.interactable = privacy.isOn && terms.isOn;
    }
}
