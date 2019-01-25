using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : MonoBehaviour
{
    public enum ButtonState { PRESSED, NOT_PRESSED };

    private bool isPressed;

    public void Start()
    {
        isPressed = false;
    }

    public void buttonReleased()
    {
        isPressed = false;
    }

    public void buttonDown()
    {
        isPressed = true;
    }

    public ButtonState getButtonState()
    {
        if (isPressed)
            return ButtonState.PRESSED;
        else
            return ButtonState.NOT_PRESSED;
    }
}
