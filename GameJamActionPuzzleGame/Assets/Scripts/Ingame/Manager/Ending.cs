﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    
    public void ExitClick()
    {
        SceneManager.LoadScene(0);
    }
}
