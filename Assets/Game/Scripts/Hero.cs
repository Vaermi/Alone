using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    // Update wird einmal pro Frame aufgerufen
    
    private void Update()
    {
        /* Movement für das Hero Objekt  für W,A,S,D / Arrow up, right, down, left / und Gamepad Left-Stick (über Hinput Gamepad Manager), 
         Frame-rate unabhängige Bewegung durch deltaTime */

        Vector3 move = new Vector3();

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Hinput.gamepad[0].leftStick.right)
        {
            move.x = 1f;

        } else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Hinput.gamepad[0].leftStick.up)
        {
            move.y = 1f;

        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Hinput.gamepad[0].leftStick.down)
        {
            move.y = -1f;

        } else if ( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Hinput.gamepad[0].leftStick.left)
        {
            move.x = -1f;
        }
            
        transform.position += move * Time.deltaTime;
        

        
    }
}
