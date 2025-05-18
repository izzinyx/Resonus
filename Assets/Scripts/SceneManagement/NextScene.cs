using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string nextScene;
    void Start()
    {
        GameManager.Instance.lastScene = SceneManager.GetActiveScene().name;
        if (nextScene == null)
        {
            Debug.Log("next scene is null!");
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
