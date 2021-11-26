using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    public Button StartButton;
    public Button ExitButton;


    private void Update()
    {
       
    }

    public void Button() 
    { 
        Debug.Log("Button Click!");
        SceneManager.LoadScene("IngameScene");
    }

    public void Exitbutton()
    {
        Debug.Log("Button");
        Application.Quit();
    }


    

}
