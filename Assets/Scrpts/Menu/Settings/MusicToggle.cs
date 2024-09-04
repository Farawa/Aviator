using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MusicToggle : MonoBehaviour
{
    private Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = MusicController.IsMusicEnabled();
        toggle.onValueChanged.AddListener(SetEnableMusic);
    }

    private void SetEnableMusic(bool isEnabled)
    {
        MusicController.Instance.SetMusicVolume(isEnabled);
    }
}
