using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{


<<<<<<< Updated upstream
   [SerializeField] private AudioClip clickSound;
=======
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject playerScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            UpdatePauseScreen(0, true, false);
        }
    }
>>>>>>> Stashed changes

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

<<<<<<< Updated upstream
=======
    public void BackToMenu()
    {
        PlayClickSound();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }

    public void ContinueGame()
    {
        UpdatePauseScreen(1, false, true);
    }

    private void UpdatePauseScreen(int newTime, bool pauseState, bool playerState)
    {
        Time.timeScale = newTime;
        pauseScreen.SetActive(pauseState);
        playerScreen.SetActive(playerState);

    }
>>>>>>> Stashed changes
}
