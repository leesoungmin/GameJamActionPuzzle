using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float bulletcoolTime;
    private float bulletcurTime;

    public int maxbulletCount;
    public int curbulletCount;

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
    bool isShout;
    public bool isLadder;
    public GameObject bullets;
    public Transform Throwpos;

    [SerializeField] GameObject healEffectPrefab;

    [SerializeField] Text text_bulletCount;

    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        curbulletCount = maxbulletCount;
    }

    void FixedUpdate()
    {
        Movement();
        Ladder();
    }
    void Update()
    {
        if (!isGround)
            Jump();

        
        Attack();
        Shout();

        text_bulletCount.text = "x" + curbulletCount.ToString();
    }
    void Ladder()
    {
        if (isLadder)
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
    void Shout()
    {
        if (bulletcurTime <= 0 && curbulletCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                SoundManager.instance.PlaySE("StoneThrow");
                curbulletCount -= 1;
                bulletcurTime = bulletcoolTime;
                anim.SetTrigger("isThrow");
            }
        }
        else
        {
            bulletcurTime -= Time.deltaTime;
        }
    }
    public void BulletSpawn()
    {
        Instantiate(bullets, Throwpos.transform.position, transform.rotation);
    }
    void Attack()
    {
        if (curTime <= 0)
        {
            //공격
            if (Input.GetKeyDown(KeyCode.J))
            {
                SoundManager.instance.PlaySE("HomiAttack");
                Collider2D[] colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.tag == "Enemy")
                    {
                        SoundManager.instance.PlaySE("AttackSFX");
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
            SoundManager.instance.PlaySE("Jump");
            isJump = true;
            rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        anim.SetBool("isJump", isJump);

    }

    void IncreaseBullet(int _num)
    {
        curbulletCount += _num;
        if (curbulletCount >= maxbulletCount)
        {
            curbulletCount = maxbulletCount;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            anim.SetBool("isClimb", isLadder);
        }
        if (collision.CompareTag("HpItem"))
        {
            StatusManager.Instance.IncreaseHp(1);
            collision.gameObject.SetActive(false);
            Instantiate(healEffectPrefab, transform.position, Quaternion.identity);
            SoundManager.instance.PlaySE("Healing");
        }

        if (collision.CompareTag("BulletItem"))
        {
            SoundManager.instance.PlaySE("Bullet");
            IncreaseBullet(4);
            collision.gameObject.SetActive(false);

        }
        if (collision.transform.CompareTag("Grounded"))
        {
            isJump = false;
            isGround = false;
        }
        if (collision.transform.CompareTag("Enemy"))
        {
            isJump = false;
            isGround = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            anim.SetBool("isClimb", isLadder);

        }


    }



}