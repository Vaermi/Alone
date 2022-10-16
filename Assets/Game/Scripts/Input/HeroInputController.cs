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
    public float speed = 10;

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
    }
}
