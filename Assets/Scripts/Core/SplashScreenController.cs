using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    private SceneHandler _sceneHandler;

    void Start()
    {
        _sceneHandler = gameObject.AddComponent<SceneHandler>();
        StartCoroutine(RunMenu(3f));
    }

    IEnumerator RunMenu(float time)
    {
        yield return new WaitForSeconds(time);

        _sceneHandler.GoMainMenu();
    }
}
