using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public Animator LogoTransition;
    public float LogoTransitionTime = 1f;

    private AudioSource _clickClip;

    public void Start()
    {
        _clickClip = gameObject.AddComponent<AudioSource>();
        _clickClip.clip = Resources.Load("Sound/drop_002", typeof(AudioClip)) as AudioClip;
    }

    public void GoMainMenu()
    {
        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicMenu>().PlayMusic();
        }
        _clickClip.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void GoSettings()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicMenu>().PlayMusic();
        _clickClip.Play();
        SceneManager.LoadScene("Settings");
    }

    public void GoLevelSelector()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicMenu>().PlayMusic();
        _clickClip.Play();
        SceneManager.LoadScene("LevelSelector");
    }

    public void GoCustomization()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicMenu>().PlayMusic();
        _clickClip.Play();
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
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicMenu>().StopMusic();
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
