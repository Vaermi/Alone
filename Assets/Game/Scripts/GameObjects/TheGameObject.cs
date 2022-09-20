using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Oberste Klasse f�r Spielobjekte im Game
/// Enth�lt Allgemeine Funktionen die f�r die meisten Szenenobjekte potenziell n�tzlich sind
/// </summary>
public class TheGameObject : MonoBehaviour
{
    // Gr��e eines Pixel-Art Pixels in Unity-Einheiten
    private static float pixelFrac = 1f / 16f;

    // Runde auf Pixel-Art Pixel
    protected float roundToPixelGrid(float f)
    {
        return Mathf.Ceil(f / pixelFrac) * pixelFrac;
    }

    // Pr�ft ob eine Kollision des BoxColliders2D dieses Spielobjekts und anderen 2D-Kollidern stattfindet
    private BoxCollider2D boxCollider;
    private Collider2D[] colliders;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        colliders = new Collider2D[10];
    }
    protected bool isColliding()
    {
        return boxCollider.OverlapCollider(new ContactFilter2D(), colliders) > 0;
    }



    /// <summary>
    /// Bewegung, die die Figur in diesem Frame vollziehen soll
    /// 1 = nach rechts/oben, -1 = nach links/unten
    /// </summary>

    public Vector3 move = new Vector3();
    private void LateUpdate()
    {
        // Anwenden der in move gesetzten Bewegung:
        float step = roundToPixelGrid(1f * Time.deltaTime);
        Vector3 oldPos = transform.position;
        //move.x = move.x * 0.2f;
        //move.y = move.y * 0.2f;
        transform.position += move * step;
        oldPos.x -= 0.1f;
        oldPos.y -= 0.1f;
        if (isColliding()) transform.position = oldPos;
        move = Vector3.zero;
    }

}