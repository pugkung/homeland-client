using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject toastMessage;
    public float exitToastInterval;
    public float floatMessageDistance;

    private Text toastTxt;
    private float lastBackPressTime;

    private void Start()
    {
        lastBackPressTime = Time.deltaTime;
    }

    private void showToast()
    {
    }

    private void hideToast()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
