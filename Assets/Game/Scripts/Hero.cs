using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Hero : MonoBehaviour
{
    private Rigidbody2D rb;
    private Tilemap tm;
    public LayerMask layerMask;
    public BoundsInt area;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tm = GetComponent<Tilemap>();
    }
    // Update wird vor einer Physik berechnet

    private void FixedUpdate()
    {
        /* Movement für das Hero Objekt  für W,A,S,D / Arrow up, right, down, left / und Gamepad Left-Stick (über Hinput Gamepad Manager), 
         Frame-rate unabhängige Bewegung durch deltaTime */






        //Bestimmen in welche Richtung der Spieler gehen will
        Vector3 move = new Vector3();

        //var wall = collider.gameObject.name.contains("")

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Hinput.gamepad[0].leftStick.right)
        {
            move.x = 1f;

        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Hinput.gamepad[0].leftStick.up)
        {
            move.y = 1f;

        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Hinput.gamepad[0].leftStick.down)
        {
            move.y = -1f;

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Hinput.gamepad[0].leftStick.left)
        {
            move.x = -1f;
        }

        //In diese Richtung schauen
        RaycastHit2D hit = Physics2D.Raycast(transform.position, move, 2, layerMask);

        //Ist in dieser Richtung ein Hindernis?
        if (hit.collider != null)
        {
            //Wenn nicht. Beweg dich dort hin
            rb.velocity = move;
            Debug.Log(hit.collider.name);
            Debug.Log(hit.collider.gameObject.name);
            Tilemap tilemap = hit.collider.GetComponent<Tilemap>();
            Debug.Log("Tilemap:");
            Debug.Log(tilemap);
            TileBase[] tileArray = tilemap.GetTilesBlock(area);
            for (int index = 0; index < tileArray.Length; index++)
            {
                Debug.Log(tileArray[index]);
                Debug.Log(tileArray[index].name);
            }
        } else
        {
            rb.velocity = move;
        }
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        //Debug.Log("Here");
    }
}
