using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTouch : MonoBehaviour
{
    public void TouchScreen()
    {
        SceneManager.LoadScene(2);
    }
}
