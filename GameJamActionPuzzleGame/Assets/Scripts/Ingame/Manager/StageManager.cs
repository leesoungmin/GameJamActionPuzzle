using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject NextPanel;
    [SerializeField] GameObject[] go_Stage;
    [SerializeField] GameObject GameClearPanel;
    public GameObject GameOverPanel;

    public int currentStage = 0;

    [SerializeField] Rigidbody2D rigidbody;
    Vector2 PlayerPos;

    private void Start()
    {
        PlayerPos = new Vector2(-16.8f, -1.31f);
    }

    void Update()
    {

    }
    //버튼에 넣기
    public void ShowNextStageUi()
    {
        NextPanel.SetActive(true);
        SoundManager.instance.PlaySE("StageClear");
    }

    public void ShowGameClear()
    {
        GameClearPanel.SetActive(true);
        StartCoroutine(goEnding());
    }

    public void NextStage()
    {
        if (currentStage < go_Stage.Length - 1)
        {

            Time.timeScale = 1;
            rigidbody.gameObject.transform.position = PlayerPos;
            NextPanel.SetActive(false);
            go_Stage[currentStage++].SetActive(false);
            go_Stage[currentStage].SetActive(true);
        }
        else
        {
            Debug.Log("골인");
        }
    }
    IEnumerator goEnding()
    {
        yield return new WaitForSeconds(3F);
        SceneManager.LoadScene(2);
    }
    public void ReplayButton()
    {
        Time.timeScale = 1;
        rigidbody.gameObject.transform.position = PlayerPos;
        SceneManager.LoadScene(1);
    }

    public void ExitClick()
    {
        Time.timeScale = 1;
        currentStage = 0;
        SceneManager.LoadScene(0);
    }
}
