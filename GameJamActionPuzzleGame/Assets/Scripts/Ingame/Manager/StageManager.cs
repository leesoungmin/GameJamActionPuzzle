using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject NextPanel;
    [SerializeField] GameObject[] go_Stage;

    int currentStage = 0;

    [SerializeField] Rigidbody2D rigidbody;
    Vector2 PlayerPos;

    private void Start()
    {
        PlayerPos = new Vector2(-19.74f, -1.31f);
    }
    //버튼에 넣기
    public void ShowNextStageUi()
    {
        NextPanel.SetActive(true);
    }
    public void NextStage()
    {
        if(currentStage < go_Stage.Length -1)
        {
            Time.timeScale = 1;
            rigidbody.gameObject.transform.position = PlayerPos;
            NextPanel.SetActive(false);
            go_Stage[currentStage++].SetActive(false);
            go_Stage[currentStage].SetActive(true);
        }
        else
        {
            Debug.Log("모든 스테이지를 클리어함");
        }
    }

    public void ExitClick()
    {
        SceneManager.LoadScene(1);
    }
}
