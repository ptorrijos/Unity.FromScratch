using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionController : MonoBehaviour
{
    public Text PowerUpScore;
    public Text OnceAgainScore;
    public Text OurMusicScore;

    void Start()
    {
        PowerUpScore.text = "SCORE: " + PlayerPrefs.GetInt(Constants.SCORE_POWERUP).ToString();
        OnceAgainScore.text = "SCORE: " + PlayerPrefs.GetInt(Constants.SCORE_ONCEAGAIN).ToString();
        OurMusicScore.text = "SCORE: " + PlayerPrefs.GetInt(Constants.SCORE_OURMUSIC).ToString();
    }
}
