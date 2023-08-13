using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum playerscontroller
{

    player1,
    player2
}

public class Controles1 : MonoBehaviour
{
    public string horizontal1 = "Horizontal1";

    public string horizontal2 = "Horizontal2";

    [SerializeField] private playerscontroller player;

    public float GetHorizontalInput()
    {
        if (player == playerscontroller.player1)
        {
            return (Input.GetAxis(horizontal1));
        }
        else if (player == playerscontroller.player2)
        {
            return (Input.GetAxis(horizontal2));
        }
        return 0f;
    }

    public bool GetInputJump()
    {
        if (player == playerscontroller.player1)
        {
            return Input.GetKeyDown(KeyCode.C);
        }
        else if (player == playerscontroller.player2)
        {
            return Input.GetKeyDown(KeyCode.RightControl);
        }
        return false;
    }
}