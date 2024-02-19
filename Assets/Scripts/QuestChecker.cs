using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestChecker : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox, finishedText, unfinishedText;
    [SerializeField] private int questGoal = 10;
<<<<<<< Updated upstream
    [SerializeField] private int levelToLoad;

=======
    [SerializeField] private AudioClip successAudio;
>>>>>>> Stashed changes

    private Animator anim;
    private bool levelIsLoading = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogBox.SetActive(true);

            if (other.GetComponent<PlayerMove>().cherryCounter >= questGoal)
            {

               // GetComponent<AudioSource>().PlayOneShot(successAudio, 0.3f);

                finishedText.SetActive(true);
                anim.SetTrigger("Flag");

<<<<<<< Updated upstream
                Invoke("LoadNextLevel", 3.0f);
=======
                other.gameObject.GetComponent<PlayerMove>().UpdatePlayerStats();

                Invoke(nameof(PrepForNextScene), 2.0f);
                Invoke(nameof(LoadNextLevel), 3.0f);
>>>>>>> Stashed changes
                levelIsLoading = true;
            }
            else
            {
                unfinishedText.SetActive(true);

            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !levelIsLoading)
        {
            dialogBox.SetActive(false);

            if (other.GetComponent<PlayerMove>().cherryCounter >= questGoal)
            {
                finishedText.SetActive(false);
            }
            else
            {
                unfinishedText.SetActive(false);

            }
        }
    }

    private void PrepForNextScene()
    {
        transitionFade.GetComponent<Animator>().SetTrigger("TransitionOut");

    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(levelToLoad);

    }
}
