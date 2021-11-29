using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : Singleton<StatusManager>
{
    [SerializeField] float blinkSpeed;
    [SerializeField] int blinkCount;

    public int maxHp;
    int currentHp;

    public bool isInvincible = false;
    bool isHurt;
    bool isknockback = false;

    [SerializeField] Text[] txt_Hp;

    public GameObject GameOverPanel;
    [SerializeField] StageManager theSM;


    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


        currentHp = maxHp;
        UpdateHpStatus();
    }

    private void Update()
    {
        
    }

    public void Hurt(int damage, Vector2 pos)
    {
        if(!isHurt)
        {
            isHurt = true;
            DereaseHp(damage);
            if (currentHp <= 0)
            {
                PlayerDead();
            }
            else
            {
                //오디오, 애니 넣기
                float x = transform.position.x - pos.x;
                if(x < 0)
                {
                    x = 1;
                }
                else
                {
                    x = -1;
                }

                //StartCoroutine(BlinkCor());
                StartCoroutine(Knockback(x));
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyAtk"))
        {
            Debug.Log("데미지받기");
            Hurt(collision.GetComponentInParent<EnemyController>().damage, collision.transform.position);
            FloatingTextManager.instance.CreateFloatingText(transform.position, "-1");
        }

    }
    public void DereaseHp(int _num)
    {
        if(!isInvincible)
        {
            currentHp -= _num;
            UpdateHpStatus();
            StartCoroutine("BlinkCor");
        }
    }

    IEnumerator Knockback(float dir)
    {
        isknockback = true;
        float ctime = 0;
        while (ctime < 0.2f)
        {
            if (transform.rotation.y == 0)
                transform.Translate(Vector2.left * 8 * Time.deltaTime * dir);
            else
                transform.Translate(Vector2.left * 8 * Time.deltaTime * -1f * dir);

            ctime += Time.deltaTime;
            yield return null;
        }
        isknockback = false;
    }

    IEnumerator BlinkCor()
    {
        isInvincible = true;

        for (int i =0; i < blinkCount * 2; i++)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkSpeed);
        }

        isInvincible = false;
        isHurt = false;
    }
    

    public void IncreaseHp(int _num)
    {
        if (currentHp == maxHp)
            return;

        currentHp += _num;
        if(currentHp >= maxHp)
        {
            currentHp = maxHp;
        }
        UpdateHpStatus();
    }
    public void UpdateHpStatus()
    {
        for(int i =0; i<txt_Hp.Length; i++)
        {
            if(i< currentHp)
            {
                txt_Hp[i].gameObject.SetActive(true);
            }
            else
            {
                txt_Hp[i].gameObject.SetActive(false);
            }
        }
    }

    public void PlayerDead()
    {
        Debug.Log("죽음");
        Time.timeScale = 0;
        theSM.GameOverPanel.SetActive(true);
        SoundManager.instance.PlaySE("GameOver");
    }

}
