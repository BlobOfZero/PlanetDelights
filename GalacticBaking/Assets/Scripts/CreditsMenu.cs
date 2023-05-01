using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CreditsMenu : MonoBehaviour
{
    public Canvas vidCanvas;
    public VideoPlayer video;
    

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        video = GetComponent<VideoPlayer>();
    }

    void OnEnable()
    {
        video .loopPointReached += LoadScene;
    }

    void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainMenu");
    }
}

