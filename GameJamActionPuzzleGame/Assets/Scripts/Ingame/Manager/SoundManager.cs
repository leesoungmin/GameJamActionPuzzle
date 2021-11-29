using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;  //mp3
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("사운드 등록")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSound;

    [Header("브금 플레이어")]
    [SerializeField] AudioSource bgmPlayer;

    [Header("효과음 플레이어")]
    [SerializeField] AudioSource[] sfxPlayer;
    void Start()
    {
        instance = this;
    }

    public void PlaySE(string _soundName)
    {
        for(int i =0; i < sfxSound.Length; i++)
        {
            if(_soundName == sfxSound[i].soundName)
            {
                for(int x =0; x  < sfxPlayer.Length; x++)
                {
                    if(!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfxSound[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
                Debug.Log("모든 효과음 플레이어가 사용중입니다!!");
                // 조건문에 걸리지 않아서 모든 mps플레이어가 작동중
                return;
            }
        }
        Debug.Log("등록된 효과음이 없습니다");
    }


}
