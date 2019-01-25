using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void gotoSetupConnectionPage()
    {
        SceneManager.LoadScene("QRScanner", LoadSceneMode.Single);
    }

    public void gotoGameControllerPage()
    {
        SceneManager.LoadScene("MainController", LoadSceneMode.Single);
    }
}
