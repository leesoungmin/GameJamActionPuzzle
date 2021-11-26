using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Text pauseText;

    //private void Update()
    //{
    //    transform.Translate(Time.deltaTime, 0, 0);

    //}
    
    //private void FixedUpdate()
    //{
            
    //}

    public void OnClickPauseButton()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseText.text = "Puase";
        }
        else
        {
            Time.timeScale = 0;
            pauseText.text = "Resume";
        }
    }
}
