using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public bool isDie;

    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {

        Movement();
    }
    void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground")))
        {
            Jump();
        }
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = Vector2.right * horizontal * speed * Time.deltaTime;

        transform.Translate(movement);

        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

    }

    void Jump()
    {
        if(Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.CompareTag("HeadBox"))
        {
            collision.transform.GetComponentInParent<EnemyController>().Destroy();
        }

    }


}
