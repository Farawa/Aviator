using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameplayButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private Action onPressedAction;
    private bool isPressed = false;

    public void SetAction(Action action)
    {
        onPressedAction += action;
    }

    private void OnDisable()
    {
        onPressedAction = null;
    }

    private void FixedUpdate()
    {
        if (!isPressed) return;
        onPressedAction?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPressed = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
}
