using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TypeOfPlayer
{
    player1,
    player2
}
public class GameInputs : MonoBehaviour
{
    [SerializeField] private TypeOfPlayer player;

    public float GetMovingX()
    {
        if (player == TypeOfPlayer.player1)
        {
            return Input.GetAxis("Horizontal1");
        }
        else if (player == TypeOfPlayer.player2)
        {
            return Input.GetAxis("Horizontal2");
        }
        return 0;
    }

    public float GetMovingY()
    {
        if (player == TypeOfPlayer.player1)
        {
            return Input.GetAxis("Vertical1");
        }
        else if (player == TypeOfPlayer.player2)
        {
            return Input.GetAxis("Vertical2");
        }
        return 0;
    }

    public bool GetInputJump()
    {
        if (player == TypeOfPlayer.player1)
        {
            return Input.GetKeyDown(KeyCode.C);
        }
        else if (player == TypeOfPlayer.player2)
        {
            return Input.GetKeyDown(KeyCode.RightControl);
        }
        return false;
    }
}
