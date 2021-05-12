using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public Animator LogoTransition;
    public float LogoTransitionTime = 1f;

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void GoLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void PlayPowerUp()
    {
        StartCoroutine(LoadLevel(Constants.LEVEL_POWERUP, "Game"));
    }

    public void PlayOnceAgain()
    {
        StartCoroutine(LoadLevel(Constants.LEVEL_ONCEAGAIN, "Game_OnceAgain"));
    }

    public void PlayOurMusic()
    {
        StartCoroutine(LoadLevel(Constants.LEVEL_OURMUSIC, "MainMenu"));
    }

    private IEnumerator LoadLevel(string levelName, string levelScene)
    {
        LogoTransition.SetTrigger("Start");

        yield return new WaitForSeconds(LogoTransitionTime);

        PlayerPrefs.SetString(Constants.SELECTED_LEVEL, levelName);
        SceneManager.LoadScene(levelScene);
    }
}
