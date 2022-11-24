using UnityEngine;

public class HeroInputController : MonoBehaviour
{
    public Hero hero;
    public float speed = 10;


    public void FixedUpdate()
    {
        Movement();
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }


    private void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
    }


    private void OpenMenu()
    {
        SceneController.PauseGame();
    }
}
