using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectBase : MonoBehaviour
{
    public int Hp;
    public int maxHp;
    public float Speed;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        Hp = maxHp;
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        
    }

    virtual protected void FixedUpdate()
    { 

    }

    virtual protected void Die()
    {

    }
    virtual protected void Att()
    {

    }
}
