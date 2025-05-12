using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHoverClick : MonoBehaviour
{
    Animator anim;
    public string nextScene;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    IEnumerator WaitForNextScene()
    {
        yield return new WaitForSeconds(0.4f);
        if (gameObject.CompareTag("Play"))
        {
            GameManager.Instance.lastScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(nextScene);
        }
        else if (gameObject.CompareTag("Quit"))
        {
            Application.Quit();
        }
    }
    private void OnMouseEnter()
    {
        anim.SetBool("Hover", true);
    }

    private void OnMouseExit()
    {
        anim.SetBool("Hover", false);
    }

    private void OnMouseDown()
    {
        anim.SetTrigger("Click");
        StartCoroutine(WaitForNextScene());
    }
}
