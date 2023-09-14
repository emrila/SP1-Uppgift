using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestChecker : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox, finishedText, unfinishedText;
    [SerializeField] private int questGoal = 10;
    [SerializeField] private int levelToLoad;


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

            if (other.GetComponent<PlayerMove>().appleCounter >= questGoal)
            {
                finishedText.SetActive(true);
                anim.SetTrigger("Flag");

                Invoke("LoadNextLevel", 3.0f);
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

            if (other.GetComponent<PlayerMove>().appleCounter >= questGoal)
            {
                finishedText.SetActive(false);
            }
            else
            {
                unfinishedText.SetActive(false);

            }
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(levelToLoad);

    }
}
