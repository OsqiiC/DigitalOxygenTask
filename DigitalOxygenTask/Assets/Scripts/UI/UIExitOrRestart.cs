using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIExitOrRestart : MonoBehaviour
{
    public static UIExitOrRestart instance;
    public GameObject[] uiElements;

    private void Awake()
    {
        instance = this;

        if(Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    public void ActivateButtons()
    {
        for (int i =0;i<uiElements.Length; i++)
        {
            uiElements[i].SetActive(true);
            if(uiElements[i].GetComponent<UITimer>() != null)
            {
                uiElements[i].GetComponent<UITimer>().ShowTime();
            }
        }

        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
