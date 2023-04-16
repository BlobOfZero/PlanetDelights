using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuController : MonoBehaviour
{
    public GameObject main;
    public Canvas credits;
    public Canvas options;
    public Canvas vidCanvas;
    public VideoPlayer video;
    

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        video = GetComponent<VideoPlayer>();
        vidCanvas.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        video .loopPointReached += LoadScene;
    }

    public void Play()
    {
        video.Play();
        vidCanvas.gameObject.SetActive(true);
        main.gameObject.SetActive(false);
    }

    void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene("CrystalMountain");
    }

    public void Options()
    {
        main.gameObject.SetActive(false);
        options.gameObject.SetActive(true);
    }

    public void BackOptions()
    {
        main.gameObject.SetActive(true);
        options.gameObject.SetActive(false);
    }

    public void Credits()
    {
        main.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
    }

    public void BackCredits()
    {
        main.gameObject.SetActive(true);
        credits.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
