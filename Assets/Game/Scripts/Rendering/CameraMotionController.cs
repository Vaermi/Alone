using UnityEngine;

/// <summary>
/// Der CameraMotionController setzt die eigene Position auf die Position des Heros
/// </summary>

public class CameraMotionController : MonoBehaviour
{
    public Hero hero;

   
    // Update is called once per frame
    void Update()
    {
        Vector3 heroPos = hero.transform.position;
        heroPos.z = transform.position.z;
        transform.position = heroPos;
    }
}
