using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private bool isGrounded = true;

    private Rigidbody2D body;
    private SpriteRenderer sprite;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Gerakan kanan
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            body.linearVelocity = new Vector2(speed, body.linearVelocity.y);
            sprite.flipX = false;
        }
        // Gerakan kiri
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            body.linearVelocity = new Vector2(-speed, body.linearVelocity.y);
            sprite.flipX = true;
        }

        // Berhenti jika tombol dilepas
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) ||
            Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            body.linearVelocity = new Vector2(0, body.linearVelocity.y);
        }

        // Melompat jika di tanah dan tekan Space
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // Cek tabrakan dengan tanah
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}