using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 startingVelocity = new Vector2(5f, 5f);

    public gameManager gameManager;

    public void resetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = startingVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {

            Vector2 newVelocity = rb.velocity;

            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2((float)(-rb.velocity.x * 1.1), rb.velocity.y);
        }
        if (collision.gameObject.CompareTag("wallPlayer"))
        {
            gameManager.scoreEnemy();
            resetBall();
        }
        if (collision.gameObject.CompareTag("wallEnemy"))
        {
            gameManager.scorePlayer();
            resetBall();
        }
    }
}
