using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : Singleton<StatusManager>
{
    [Header("Player Status")]
    public int Hp = 100;
    public float Speed = 50f;
    public float JumpPower = 10f;

    
}
