using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string lastScene;
    public string lastRoom;
    public GameObject lastCam;

    public GameObject pausePanel;
    public float musicVolume;
    public float sfxVolume;

    //Start Variables
    public bool finishedInteraction;
    public Vector3 playerPos;

    //Good Route Variables
    public List<GameObject> enemiesFought;

    //Bad Route Variables
    public bool hiding;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Main Menu" && SceneManager.GetActiveScene().name != "Save Select")
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        if(pausePanel == null)
        {
            pausePanel = GameObject.FindGameObjectWithTag("Pause");
        }
        Debug.Log("Paused");
        if (pausePanel.activeInHierarchy)
        {
            GameObject options = GameObject.Find("OptionsBG");
            if (options != null)
            {
                options.SetActive(false);
            }
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
