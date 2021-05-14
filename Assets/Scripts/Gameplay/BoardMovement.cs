using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public GameObject Board;

    private float _angleSettings;

    void Start()
    {
        SetupBoard();
        _angleSettings = (PlayerPrefs.GetInt(Constants.SETTINGS_REVERSECONTROLS) == 0 ? 180 : 0);
    }

    void Update()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen) - _angleSettings;

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void SetupBoard()
    {
        string boardSpriteName = PlayerPrefs.GetString(Constants.SELECTED_BOARD);

        if (boardSpriteName == string.Empty)
        {
            boardSpriteName = Constants.BOARD_DEFAULT;
            PlayerPrefs.SetString(Constants.SELECTED_BOARD, Constants.BOARD_DEFAULT);
        }

        Sprite boardSprite = Resources.Load(Constants.BOARD_PATH + boardSpriteName, typeof(Sprite)) as Sprite;

        var BoardImage = Board.GetComponent<SpriteRenderer>();
        BoardImage.sprite = boardSprite;
    }
}
