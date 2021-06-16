using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public KeyCode moveUp, moveDown;
    public float speed = 10f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(moveUp))
            rb.velocity = new Vector2(0, speed);
        else if (Input.GetKey(moveDown))
            rb.velocity = new Vector2(0, -speed);
        else
            rb.velocity = new Vector2(0, 0);

        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}
