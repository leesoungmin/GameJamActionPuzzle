using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager instance;

    [SerializeField] GameObject FloatingText;

    private void Start()
    {
        instance = this;
    }

    public void CreateFloatingText(Vector3 pos, string _txt)
    {
        GameObject clone = Instantiate(FloatingText, pos, FloatingText.transform.rotation);
        clone.GetComponentInChildren<Text>().text = _txt;
    }
}
