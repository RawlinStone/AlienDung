using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsPanel;

    public void startGame()
    {
        SceneManager.LoadScene(0);
    }

    public void showCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void closeCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void quitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}