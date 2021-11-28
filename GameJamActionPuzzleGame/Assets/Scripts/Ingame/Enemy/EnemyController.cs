using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int currentHp;
    public int maxHP;

    public float Speed;
    public int nextMove;
    public int damage;

    public int blinkCount;
    public float blinkSpeed;

    public float coolTime;
    float currentTime;

    bool isDie;

    public Transform pos;
    public BoxCollider2D box;
    public Animator anim;

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        currentHp = maxHP;
    }

    void FixedUpdate()
    {
        Movement();

    }

    private void Update()
    {
        Attakc();
        Dead();
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
        else if (nextMove > 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    void Turn()
    {
        nextMove *= -1;
        box.transform.localScale *= -1;
        pos.localPosition *= new Vector2(-1, 1);
        spriteRenderer.flipX = nextMove == 1;
    }
    void Dead()
    {
        if (currentHp <= 0)
            Destroy(gameObject);
    }

    void Attakc()
    {
        Collider2D[] collider = Physics2D.OverlapBoxAll(pos.position, new Vector2(2f, 2f), 2);
        if (currentTime <= 0)
        {
            if (collider != null)
            {
                for (int i = 0; i < collider.Length; i++)
                {
                    if (collider[i].tag == "Player")
                    {
                        anim.SetTrigger("isAtt");
                    }
                    currentTime = coolTime;
                }
            }
        }
        else
        {
            currentTime -= Time.deltaTime;

        }

    }

    public void enBox()
    {
        box.enabled = true;
    }

    public void deBox()
    {
        box.enabled = false;
    }

    public void DecreaseHp(int _num)
    {
        if (!isDie)
        {
            currentHp -= _num;
            StartCoroutine("BlinkCor");
            FloatingTextManager.instance.CreateFloatingText(transform.position,"-1");
        }
    }
    IEnumerator BlinkCor()
    {
        for (int i = 0; i < blinkCount * 2; i++)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
    

}
