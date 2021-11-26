using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed;
    public int nextMove;

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Think();

        Invoke("Think", 2f);
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 move = new Vector2(nextMove * Speed * Time.deltaTime, 0);

        transform.Translate(move);

        Vector2 frontVec = new Vector2(rigidbody.position.x + nextMove * 0.2f, rigidbody.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0)); //초록색
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));
        if (rayHit.collider == null)
        {
            Turn();
        }

        if (nextMove < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(nextMove >0 )
        {
            spriteRenderer.flipX = true;
        }
    }

    void Turn()
    {
        nextMove *= -1;

        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke();
        Invoke("Think", 2);
    }
    void Think()
    {
        nextMove = Random.Range(-1, 2);

        Invoke("Think", 2);

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
