using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectBase : MonoBehaviour
{
    int Hp;
    int maxHp;
    float Speed;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Hp = maxHp;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
