using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LevelReset()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void HubReturn()
    {
        SceneManager.LoadScene("GameHub");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
