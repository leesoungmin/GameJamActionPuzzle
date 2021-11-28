using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComeCamera : MonoBehaviour
{
    public float cameraSpeed = 5f;

    public GameObject player;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        Vector3 dir = player.transform.position - transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);

        this.transform.Translate(moveVector);
    }
}
