using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void PlayPowerUp()
    {
        PlayerPrefs.SetString(Constants.SELECTED_LEVEL, Constants.LEVEL_POWERUP);
        SceneManager.LoadScene("Game");
    }

    public void PlayOnceAgain()
    {
        PlayerPrefs.SetString(Constants.SELECTED_LEVEL, Constants.LEVEL_ONCEAGAIN);
        SceneManager.LoadScene("Game_OnceAgain");
    }

    public void PlayOurMusic()
    {
        PlayerPrefs.SetString(Constants.SELECTED_LEVEL, Constants.LEVEL_OURMUSIC);
        SceneManager.LoadScene("MainMenu");
    }
}
