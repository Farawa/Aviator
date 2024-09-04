using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Toggle))]
public class SoundsToggle : MonoBehaviour
{
    private Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = MusicController.IsSoundsEnabled();
        toggle.onValueChanged.AddListener(SetEnableSounds);
    }

    private void SetEnableSounds(bool isEnabled)
    {
        MusicController.SetSoundsVolume(isEnabled);
    }
}
