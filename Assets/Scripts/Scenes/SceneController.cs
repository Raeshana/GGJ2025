using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMoonLandingLevel()
    {
        SceneManager.LoadScene("MoonLandingLevel", LoadSceneMode.Single);
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
