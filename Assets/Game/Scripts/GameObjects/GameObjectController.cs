using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Oberste Klasse f�r Spielobjekte im Game
/// Enth�lt Allgemeine Funktionen die f�r die meisten Szenenobjekte potenziell n�tzlich sind
/// </summary>
public class GameObjectController : MonoBehaviour
{
    public Vector3 Move = new Vector3();
    private static float pixelFrac = 1f / 16f;      // Gr��e eines Pixel-Art Pixels in Unity-Einheiten
    private BoxCollider2D boxCollider;
    private Collider2D[] colliders;

   
    private void Awake()
    {
        // Pr�ft ob eine Kollision des BoxColliders2D dieses Spielobjekts und anderen 2D-Kollidern stattfindet
        boxCollider = GetComponent<BoxCollider2D>();
        colliders = new Collider2D[10];
    }


    protected float roundToPixelGrid(float f)
    {
        return Mathf.Ceil(f / pixelFrac) * pixelFrac;
    }


    protected bool isColliding()
    {
        if (boxCollider != null)
        {
            return boxCollider.OverlapCollider(new ContactFilter2D(), colliders) > 0;
        }
        return boxCollider;
    }


    private void LateUpdate()
    {
        // Anwenden der in move gesetzten Bewegung:
        float step = roundToPixelGrid(1f * Time.deltaTime);
        Vector3 oldPos = transform.position;
        transform.position += Move * step;
        if (isColliding()) transform.position = oldPos;
        Move = Vector3.zero;
    }

}
