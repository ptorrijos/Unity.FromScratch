using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Lives = 10;
    public int Score = 0;
    public Text ScoreDisplay;
    public Text LivesDisplay;
    public AudioSource Audio;
    public string ScoreMusicKey;

    public static GameController current;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        Score = 0;
        Lives = 10;
    }

    private void Update()
    {
        ScoreDisplay.text = "SCORE: " + Score.ToString();
        LivesDisplay.text = "LIVES: " + Lives.ToString();

        if (!Audio.isPlaying)
        {
            string scoreTag = "";

            switch(PlayerPrefs.GetString(Constants.SELECTED_LEVEL))
            {
                case Constants.LEVEL_POWERUP:
                    scoreTag = Constants.SCORE_POWERUP;
                    break;
                case Constants.LEVEL_ONCEAGAIN:
                    scoreTag = Constants.SCORE_ONCEAGAIN;
                    break;
                case Constants.LEVEL_OURMUSIC:
                    scoreTag = Constants.SCORE_OURMUSIC;
                    break;
            }

            if (PlayerPrefs.GetInt(scoreTag) < Score)
            {
                PlayerPrefs.SetInt(scoreTag, Score);
                SceneManager.LoadScene("LevelSelector");
            }
        }
    }

    public void BallMissed()
    {
        Lives--;

        if (Lives <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void BallCatched()
    {
        Score++;
    }
}
