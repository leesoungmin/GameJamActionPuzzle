using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamSkill : MonoBehaviour
{

    public GameObject player;
    public int numnum = 5;

    void Start()
    {
        InvokeRepeating("countdown", 1f, 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (numnum >= 5)
        {
            if (collision.gameObject.name == "Player")
            {
                Debug.Log("충돌");
                EnemyController call = GameObject.Find("icon_9").GetComponent<EnemyController>();
                call.Speed = 10f;
                Invoke("nextmove",3f);
                Invoke("nextmove22", 2f);
                numnum = 0;
            }
        }
    }
    void nextmove()
    {
        EnemyController call = GameObject.Find("icon_9").GetComponent<EnemyController>();
        call.Speed = 0f;
    }
    void nextmove22()
    {
        EnemyController call = GameObject.Find("icon_9").GetComponent<EnemyController>();
        call.Speed = 2;
    }

    void countdown()
    {
        if (numnum < 5)
        {
        
            numnum++;
        }
    }
}