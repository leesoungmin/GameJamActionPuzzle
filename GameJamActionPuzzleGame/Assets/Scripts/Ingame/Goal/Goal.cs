using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] StageManager thsSM;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("골");
            Time.timeScale = 0;
            if(thsSM.currentStage <= 1)
            {
                thsSM.ShowNextStageUi();
            }
            else
            {
                StartCoroutine("GameEnding");
            }
        }
    }
    IEnumerator GameEnding()
    {
        thsSM.GameClearUi();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(3);
    }
}
