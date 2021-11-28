using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject PausePopupPanel;



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickPauseButton();
        }
    }



    public void rePlay()
    {
        PausePopupPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void OnClickPauseButton()
    {
        Time.timeScale = 0;
        PausePopupPanel.SetActive(true);
    }
}
