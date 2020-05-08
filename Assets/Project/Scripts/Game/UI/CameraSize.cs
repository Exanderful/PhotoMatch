using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GEM.Game.Common;

public class CameraSize : MonoBehaviour
{
    public GameBoard GameBoard;

    void Start()
    {
        if(GameBoard.level.width == 6)
        {
            GetComponent<Camera>().orthographicSize = 10.7f;
        }
        else if(GameBoard.level.width == 7)
        {
            GetComponent<Camera>().orthographicSize = 12.3f;
        }
        else if (GameBoard.level.width == 8)
        {
            GetComponent<Camera>().orthographicSize = 14f;
        }
        else if (GameBoard.level.width == 9)
        {
            GetComponent<Camera>().orthographicSize = 15.7f;
        }
    }
}
