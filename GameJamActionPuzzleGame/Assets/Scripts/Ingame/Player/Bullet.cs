using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    // Update is called once per frame

    void Update()
    {
        GameObjectDestroy();
        BulletShout();
    }
    void BulletShout()
    {
        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * bulletSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * bulletSpeed * Time.deltaTime);
        }
    }
    void GameObjectDestroy()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().DecreaseHp(1);
            Destroy(gameObject);
        }
        if(collision.CompareTag("Grounded"))
        {
            Destroy(gameObject);    

        }
    }
}
