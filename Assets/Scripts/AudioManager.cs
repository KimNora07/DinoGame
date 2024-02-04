using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[Serializable]
public class Sound
{                   // 사운드 클립과 이름을 관리하기 위해 사용
    public string name;               // 이름을 지어준다
    public AudioClip clip;            // 오디오 클립
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }  // static을 사용하여 싱글톤 등록

    //오디오 클립 배열
    public Sound[] musicSound;  // 사용할 사운드 선언
    public Sound[] sfxSound;    // 사용할 사운드 선언

    public AudioSource musicSource;  // 사용할 오디오 소스 선언
    public AudioSource sfxSource;    // 사용할 오디오 소스 선언

    // 오디오 옵션
    public AudioMixer mixer;                   // 사용할 오디오 믹서

    const string MIXER_MUSIC = "MusicVolume";  // 사용할 Param값 (music)
    const string MIXER_SFX = "SFXVolume";      // 사용할 Param값 (sfx)

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    public void PlayMusic(string name)
    {  // 재생할 BGM 함수 생성
        Sound sound = Array.Find(musicSound, x => x.name == name);  // Array 람다식 name을 찾아서 반환

        if (sound == null)
        {                  // name으로 된 wav가 없을 경우 Log 출력
            Debug.Log("Sound Not Found!");
        }
        else
        {
            musicSource.clip = sound.clip;  // 생성한 오디오 소스에 클립을 넣는다.
            musicSource.Play();             // 일반 Play 재생
        }
    }
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSound, x => x.name == name);  // Array 람다식 name을 찾아서 반환

        if (sound == null)
        {                  // name으로 된 wav가 없을 경우 Log 출력
            Debug.Log("Sound Not Found!");
        }
        else
        {
            sfxSource.PlayOneShot(sound.clip);  // 일반 Play 재생
        }
    }

}
