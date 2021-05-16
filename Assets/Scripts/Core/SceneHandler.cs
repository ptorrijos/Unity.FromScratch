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

    public void GoCustomization()
    {
        SceneManager.LoadScene("Customization");
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

    public void ReloadLevel()
    {
        StartCoroutine(DoReloadLevel());
    }

    private IEnumerator LoadLevel(string levelName, string levelScene)
    {
        Time.timeScale = 1f;
        LogoTransition.SetTrigger("Start");

        PlayerPrefs.SetInt(Constants.GAME_PAUSE, 0);
        PlayerPrefs.SetString(Constants.SELECTED_LEVEL, levelName);

        yield return new WaitForSeconds(LogoTransitionTime);

        SceneManager.LoadScene(levelScene);
    }

    private IEnumerator DoReloadLevel()
    {
        Time.timeScale = 1f;

        LogoTransition.SetTrigger("Start");

        yield return new WaitForSeconds(LogoTransitionTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        PlayerPrefs.SetInt(Constants.GAME_PAUSE, 0);
    }
}
