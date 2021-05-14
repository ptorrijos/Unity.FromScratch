using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardSelectionController : MonoBehaviour
{
    public string BoardReference;
    public Button BoardButton;
    public Text Score;

    void Start()
    {
        FirstSetup();

        string boardSpriteName;

        if (PlayerPrefs.GetInt(BoardReference) == 1)
        {
            boardSpriteName = BoardReference;
        }
        else
        {
            boardSpriteName = Constants.BOARD_BLANK;
        }

        Sprite boardSprite = Resources.Load(Constants.BOARD_PATH + boardSpriteName, typeof(Sprite)) as Sprite;
        BoardButton.image.sprite = boardSprite;

        Score.text = "SCORE: " + PlayerPrefs.GetInt("SCORE_" + BoardReference).ToString();
    }

    void Update()
    {
        if (PlayerPrefs.GetString(Constants.SELECTED_BOARD) == BoardReference)
        {
            BoardButton.Select();
        }
    }

    public void SelectBoard()
    {
        if (PlayerPrefs.GetInt(BoardReference) == 1)
        {
            PlayerPrefs.SetString(Constants.SELECTED_BOARD, BoardReference);
        }
    }

    private void FirstSetup()
    {
        if (PlayerPrefs.GetString(Constants.SELECTED_BOARD) == string.Empty)
        {
            PlayerPrefs.SetString(Constants.SELECTED_BOARD, Constants.BOARD_DEFAULT);
        }

        if (PlayerPrefs.GetInt(Constants.BOARD_DEFAULT) == 0)
        {
            PlayerPrefs.SetInt(Constants.BOARD_DEFAULT, 1);
        }

        if (DateTime.Now.Year <= 2021)
        {
            PlayerPrefs.SetInt(Constants.BOARD_EARLYADOPTER, 1);
        }
    }
}
