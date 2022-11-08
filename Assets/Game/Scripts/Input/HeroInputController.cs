using UnityEngine;

public class HeroInputController : MonoBehaviour
{
    public Hero hero;
    public float speed = 10;


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
    }
}
