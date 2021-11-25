using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : Singleton<StatusManager>
{
    [Header("Player Status")]
    public int Hp = 3;
    public float Speed = 8;
    public float JumpPower = 15;

    
}
