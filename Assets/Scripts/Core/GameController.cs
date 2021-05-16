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
    public int MissedBalls = 0;
    public Text ScoreDisplay;
    public Text LivesDisplay;
    public string ScoreMusicKey;

    public static GameController current;

    private AudioSource _music;

    void Start()
    {
        PlayerPrefs.SetInt(Constants.GAME_PAUSE, 0);
        current = this;
        Score = 0;
        MissedBalls = 0;
        Lives = 100;

        _music = GetComponent<AudioSource>();

    }

    private void Update()
    {
        bool pausedGame = PlayerPrefs.GetInt(Constants.GAME_PAUSE) == 1;

        if (pausedGame && _music.isPlaying)
        {
            _music.Pause();
        }
        if (!pausedGame && !_music.isPlaying)
        {
            _music.UnPause();
        }

        ScoreDisplay.text = "SCORE: " + Score.ToString();
        LivesDisplay.text = "LIVES: " + Lives.ToString();

        if (_music.time >= _music.clip.length)
        {
            Invoke("FinishGame", 1f);
        }
    }

    public void BallMissed()
    {
        MissedBalls++;
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

    private void FinishGame()
    {
        // Set level scoring if needed
        string scoreTag = "";

        switch (PlayerPrefs.GetString(Constants.SELECTED_LEVEL))
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
        }

        // Set board scoring if needed
        if (PlayerPrefs.GetInt("SCORE_" + PlayerPrefs.GetString(Constants.SELECTED_BOARD)) < Score)
        {
            PlayerPrefs.SetInt("SCORE_" + PlayerPrefs.GetString(Constants.SELECTED_BOARD), Score);
        }

        // Increase player scoring
        PlayerPrefs.SetInt(Constants.SCORE_PLAYER, PlayerPrefs.GetInt(Constants.SCORE_PLAYER) + Score);

        // Check achievements
        int playerScore = PlayerPrefs.GetInt(Constants.SCORE_PLAYER);

        if (playerScore > 10000)
        {
            PlayerPrefs.SetInt(Constants.BOARD_GATHERER, 1);
        }

        if (playerScore > 384400)
        {
            PlayerPrefs.SetInt(Constants.BOARD_ACCUMULATOR, 1);
        }

        if (playerScore > 1000000)
        {
            PlayerPrefs.SetInt(Constants.BOARD_COMPILER, 1);
        }

        if (Score > 400 && MissedBalls == 0)
        {
            PlayerPrefs.SetInt(Constants.BOARD_FINEWORK, 1);
        }

        if (Score == 1024)
        {
            PlayerPrefs.SetInt(Constants.BOARD_1KB, 1);
        }

        if (MissedBalls > 400 && Score == 0)
        {
            PlayerPrefs.SetInt(Constants.BOARD_RATKID, 1);
        }

        // End game
        SceneManager.LoadScene("LevelSelector");
    }
}
