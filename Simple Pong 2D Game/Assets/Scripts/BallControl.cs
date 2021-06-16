using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject ball;
    Vector2 v2;
    float ballSpeed = 100f;
    AudioSource audioSound;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        audioSound = GetComponent<AudioSource>();
        GoBall();
    }

    void Update()
    {
        float xVel = rb.velocity.x;
        if(xVel < 18 && xVel > -18 && xVel != 0)
        {
            if (xVel > 0)
                rb.velocity = new Vector2(20f, rb.velocity.y);
            else
                rb.velocity = new Vector2(-20f, rb.velocity.y);
        }

    }
    
    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.collider.tag == "Player") {
            v2.y = rb.velocity.y / 2 + colInfo.collider.GetComponent<Rigidbody2D>().velocity.y/3;
            rb.velocity = new Vector2(rb.velocity.x, v2.y);
            audioSound.pitch = Random.Range(0.8f, 1.2f);
            audioSound.Play();
        }
    }

    IEnumerator ResetBall()
    {
        v2.y = v2.x = 0;
        rb.velocity = new Vector2(v2.x, v2.y);
        ball.transform.position = new Vector2(0f, 0f);
        yield return new WaitForSeconds(0.5f);
        GoBall();
    }

    void GoBall()
    {
        rb = GetComponent<Rigidbody2D>();
        v2 = rb.velocity;
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber <= 0.5f)
            rb.AddForce(new Vector2(ballSpeed, 10));
        else
            rb.AddForce(new Vector2(-ballSpeed, -10));
    }
}