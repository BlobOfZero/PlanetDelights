using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);

    }

    public void PauseGame()
    {
        
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
     SceneManager.LoadScene("GameHub");   
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
