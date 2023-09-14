using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{


   [SerializeField] private AudioClip clickSound;

    public void StartGame()
    {
        PlayClickSound();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        PlayClickSound();
        Application.Quit();
    }

    private void PlayClickSound()
    {
        GetComponent<AudioSource>().PlayOneShot(clickSound, 0.5f);
    }

}
