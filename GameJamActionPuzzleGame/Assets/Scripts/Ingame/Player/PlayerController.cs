using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float coolTime = 0.5f;
    float curTime;

    public Transform pos;
    public Vector2 boxSize;

    public float speed;
    public float jumpPower;
    public bool isDie;
    public int damage = 1;

    bool isMoving;
    bool isJump;
    bool isGround;
    public bool isLadder;

    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Movement();
        Ladder();
    }
    void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground")))
        {
            Jump();
        }

        Attack();
    }
    void Ladder()
    {
        if(isLadder)
        {
            float ver = Input.GetAxis("Vertical");
            rigidbody2D.gravityScale = 0;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, ver * speed);
        }
        else
        {
            rigidbody2D.gravityScale = 4;
        }
    }
    void Movement()
    {

        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Vector2 movement = Vector3.right * speed * Time.deltaTime;

            transform.Translate(movement);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Vector2 movement = Vector3.right * speed * Time.deltaTime;

            transform.Translate(movement);
        }
        else
        {
            isMoving = false;
        }

        anim.SetBool("isMoving", isMoving);



    }
    void Attack()
    {

        if (curTime <= 0)
        {
            //공격
            if (Input.GetKeyDown(KeyCode.J))
            {
                Collider2D[] colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in colliders)
                {
                    if(collider.tag == "Enemy")
                    {
                        collider.GetComponent<EnemyController>().DecreaseHp(damage);
                    }
                }

                anim.SetTrigger("isAttack");
                curTime = coolTime;
            }

        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.K) && Time.timeScale == 1 && !isJump)
        {
            isJump = true;
            rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        anim.SetBool("isJump", isJump);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Grounded"))
        {
            isGround = true;
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Grounded"))
        {
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
        }
    }
}
