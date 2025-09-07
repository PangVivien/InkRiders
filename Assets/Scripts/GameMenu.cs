using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject Settings;
    public GameObject Gallery;
    public VideoPlayer backgroundVideo;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        if(backgroundVideo != null)
        {
            backgroundVideo.Stop();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void GameGallery()
    {
        Gallery.SetActive(true);
    }

    public void GameOption()
    {
        Settings.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CancelGallery()
    {
        Gallery.SetActive(false);
    }

    public void CancelSetting()
    {
        Settings.SetActive(false);
    }

}
