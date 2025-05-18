using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public void Resume()
    {
        GameManager.Instance.PauseGame();
    }

    public void Options()
    {
        optionsPanel.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        GameManager.Instance.PauseGame();
    }

    public void Back()
    {
        optionsPanel.SetActive(false);
    }
}
