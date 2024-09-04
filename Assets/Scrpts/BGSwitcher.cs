using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject previewBG;
    [SerializeField] private GameObject menuBG;
    [SerializeField] private GameObject gameBG;

    public void SetBG(BGType type)
    {
        previewBG.SetActive(false);
        menuBG.SetActive(false);
        gameBG.SetActive(false);
        switch (type)
        {
            case BGType.preview:
                previewBG.SetActive(true);
                break;
            case BGType.menu:
                menuBG.SetActive(true);
                break;
            case BGType.game:
                gameBG.SetActive(true);
                break;
        }
    }
}

public enum BGType
{
    preview,
    menu,
    game
}
