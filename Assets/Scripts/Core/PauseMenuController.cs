using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Animator PauseTransition;
    public float PauseTransitionTime = 1f;
    public Button PauseButton;
    public SceneHandler SceneHandler;

    public void Pause()
    {
        StartCoroutine(DoPause());
    }

    public void Resume()
    {
        StartCoroutine(DoResume());
    }

    public void Home()
    {
        SceneHandler.GoLevelSelector();
    }

    public void Restart()
    {
        SceneHandler.ReloadLevel();
    }

    private IEnumerator DoPause()
    {
        PauseButton.gameObject.SetActive(false);
        PauseTransition.SetTrigger("Show");
        yield return new WaitForSeconds(PauseTransitionTime);
        Time.timeScale = 0f;
        PlayerPrefs.SetInt(Constants.GAME_PAUSE, 1);
    }

    private IEnumerator DoResume()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt(Constants.GAME_PAUSE, 0);
        PauseButton.gameObject.SetActive(true);
        PauseTransition.SetTrigger("Hide");
        yield return new WaitForSeconds(PauseTransitionTime);
    }
}
