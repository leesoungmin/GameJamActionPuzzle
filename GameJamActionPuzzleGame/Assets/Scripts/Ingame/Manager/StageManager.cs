using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject[] go_Stage;

    int currentStage = 0;

    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Transform tf_originPos;

    //버튼에 넣기
    public void NextStage()
    {
        Time.timeScale = 1;
        rigidbody.gameObject.transform.position = tf_originPos.position;
        go_Stage[currentStage++].SetActive(false);
        go_Stage[currentStage].SetActive(true);
    }
}
