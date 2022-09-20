using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotionController : MonoBehaviour
{
    public Hero hero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 heroPos = hero.transform.position;
        heroPos.z = transform.position.z;
        transform.position = heroPos;
    }
}
