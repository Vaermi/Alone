using UnityEngine;

public class CameraMotionController : MonoBehaviour
{
    public Hero hero;

   
    void Update()
    {
        Vector3 heroPos = hero.transform.position;
        heroPos.z = transform.position.z;
        transform.position = heroPos;
    }
}
