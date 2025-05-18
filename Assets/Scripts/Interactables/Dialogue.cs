using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public AudioSource d_audioSource;

    public GameObject player;
    public PlayerController playerController;
    public TextMeshProUGUI textComponent;
    public GameObject dialoguePanel;
    public string[] lines;
    public float textSpeed;

    public int index;
    public bool hasChoices;
    public GameObject choices;
    float timer;

    public GameObject classroomPaper;
    public string sceneName;

    private void OnEnable()
    {
        //Search for player on scene
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerController = player.GetComponent<PlayerController>();
        }

        //Reset dialogue box to start
        textComponent.text = string.Empty;
        StartDialogue();
    }
    
    void Update()
    {
        //Skip dialogue?
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                d_audioSource.Stop();
                textComponent.text = lines[index];
            }
        }
        if (textComponent.text == lines[index] && Input.GetKeyDown(KeyCode.E) == false)
        {
            //Finished sentence?
            if (index < lines.Length - 1)
            {
                timer += Time.deltaTime;
                if (timer > 1.25f)
                {
                    NextLine();
                    timer = 0;
                }
            }
            else
            {
                //Choices?
                if (hasChoices)
                {
                    choices.SetActive(true);
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timer > 1.25f)
                    {
                        NextLine();
                        timer = 0;
                    }
                }
            }
        }
    }

    void StartDialogue()
    {
        playerController.enabled = false;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        d_audioSource.volume = GameManager.Instance.sfxVolume;
        d_audioSource.Play();
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        d_audioSource.Stop();
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //Choices?
            if (hasChoices)
            {
                choices.SetActive(true);
            }
            else
            {
                //Finished classroom cutscene-interaction?
                if (SceneManager.GetActiveScene().name == "ClassroomAfterPaper")
                {
                    GameManager.Instance.finishedInteraction = true;
                }
            }

            //Reset components for replay
            if (gameObject.CompareTag("NextScene") && sceneName != null)
            {
                GameManager.Instance.lastScene = SceneManager.GetActiveScene().name;
                GameManager.Instance.playerPos = player.transform.position;
                SceneManager.LoadScene(sceneName);
            }

            if (gameObject.CompareTag("ToFlip"))
            {
                GameObject fr = GameObject.Find("Friend1");
                SpriteRenderer sr = fr.GetComponent<SpriteRenderer>();
                sr.flipX = false;
            }

            if(classroomPaper != null)
            {
                classroomPaper.SetActive(false);
                GameObject eselor = GameObject.Find("Eselor");
                PlayableDirector timeline = eselor.GetComponent<PlayableDirector>();
                timeline.Play();
                dialoguePanel.SetActive(false);
                textComponent.text = string.Empty;
            }
            else
            {
                dialoguePanel.SetActive(false);
                index = 0;
                textComponent.text = string.Empty;
                playerController.enabled = true;
            }

            gameObject.SetActive(false);
        }
    }
}
