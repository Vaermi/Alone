using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    // Update is called once per frame
    
    private void Update()
    {
        Vector3 change = new Vector3();

        if (Input.GetKey(KeyCode.D))
        {
            change.x = 1f;

        } else if (Input.GetKey(KeyCode.W))
        {
            change.y = 1f;

        } else if (Input.GetKey(KeyCode.S))
        {
            change.y = -1f;

        } else if ( Input.GetKey(KeyCode.A))
        {
            change.x = -1f;
        }
            
        transform.position += change * Time.deltaTime;
        

        
    }
}
