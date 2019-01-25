using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleDebug : MonoBehaviour
{
    public GameObject dPadOject;
    public GameObject aButtonObject;
    public GameObject consoleObject;

    private VirtualJoystick joyStickInput;
    private ActionButton buttonListener;
    private Text consoleOutput;

    string outTxt;

    // Start is called before the first frame update
    void Start()
    {
        joyStickInput = dPadOject.GetComponent(typeof(VirtualJoystick)) as VirtualJoystick;
        buttonListener = aButtonObject.GetComponent(typeof(ActionButton)) as ActionButton;
        consoleOutput = consoleObject.GetComponent(typeof(Text)) as Text;
    }

    // Update is called once per frame
    void Update()
    {
        outTxt = "Test Input\n";
        outTxt += "[ X ] : " + joyStickInput.getX() + "\n";
        outTxt += "[ Y ] : " + joyStickInput.getY() + "\n";
        if (buttonListener.getButtonState() == ActionButton.ButtonState.PRESSED)
        {
            outTxt += "[ Action ]\n";
        }

        consoleOutput.text = outTxt;

    }
}
