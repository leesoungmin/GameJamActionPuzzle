using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void ButtonClickSound()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.Play();

    }
}
