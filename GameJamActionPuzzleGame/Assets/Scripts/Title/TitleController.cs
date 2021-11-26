using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitleController : MonoBehaviour
{
    public GameObject popUp;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           if (EventSystem.current.IsPointerOverGameObject() == false)
           {
               popUp.SetActive(false);
           }
        }
    }

}
