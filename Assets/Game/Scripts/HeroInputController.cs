using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Leitet Eingaben aus, die die Spielfigur steuern sollen
/// und leitet sie an das zu steuernde Heroscript weiter
/// </summary>
public class HeroInputController : MonoBehaviour
{
    public Hero hero;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Hinput.gamepad[0].leftStick.right)
        {
            hero.move.x = 1;

        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Hinput.gamepad[0].leftStick.up)
        {
            hero.move.y = 1;

        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Hinput.gamepad[0].leftStick.down)
        {
            hero.move.y = -1;

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Hinput.gamepad[0].leftStick.left)
        {
            hero.move.x = -1;
        }
    }
}
