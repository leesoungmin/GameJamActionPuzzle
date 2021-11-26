using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    [SerializeField] float blinkSpeed;
    [SerializeField] int blinkCount;

    [SerializeField] int maxHp;
    int currentHp;

    public bool isInvincible = false;

    [SerializeField] Text[] txt_Hp;

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

    public void DereaseHp(int _num)
    {
        if(!isInvincible)
        {
            currentHp -= _num;
            UpdateHpStatus();
            StartCoroutine("BlinkCor");
        }
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
    void UpdateHpStatus()
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
        if(currentHp <= 0)
        {
            Debug.Log("죽음");
            Time.timeScale = 0;
        }
    }
}
