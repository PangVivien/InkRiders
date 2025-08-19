using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePaused : MonoBehaviour
{
    // [SerializeField] private AudioSource AudioSource;
    // [SerializeField] private AudioClip AudioClip;
    [SerializeField] private Image playPauseButton;
    [SerializeField] public GameObject UIPanel;

    public static bool isPaused = false;

    void Update()
    {

    }

    public void Pause()
    {
        //AudioSource.PlayOneShot(AudioClip);
        Time.timeScale = 0f;
        UIPanel.SetActive(true);
    }


    public void Resume()
    {
        //AudioSource.PlayOneShot(AudioClip);
        Time.timeScale = 1f;
        UIPanel.SetActive(false);
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
