using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage = 1;
    public int Force = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<StatusManager>().Hurt(damage, collision.transform.position);
            collision.rigidbody.velocity = Vector3.up * Force;
            SoundManager.instance.PlaySE("SteelTrap");
        }
    }
}
