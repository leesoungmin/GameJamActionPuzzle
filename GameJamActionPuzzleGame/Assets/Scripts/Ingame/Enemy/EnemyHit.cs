using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] float force;

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.transform.CompareTag("Player") && collision.transform.GetComponent<StatusManager>().isInvincible == false)
        {
            Debug.Log(damage + "를 입힘");
            collision.transform.GetComponent<StatusManager>().DereaseHp(damage);
            collision.transform.GetComponent<StatusManager>().PlayerDead();
            collision.transform.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
            string message = "-" + damage;
            FloatingTextManager.instance.CreateFloatingText(collision.transform.position, message);


        }
    }
}
