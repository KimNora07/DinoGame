using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[Serializable]
public class Sound
{                   // ���� Ŭ���� �̸��� �����ϱ� ���� ���
    public string name;               // �̸��� �����ش�
    public AudioClip clip;            // ����� Ŭ��
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }  // static�� ����Ͽ� �̱��� ���

    //����� Ŭ�� �迭
    public Sound[] musicSound;  // ����� ���� ����
    public Sound[] sfxSound;    // ����� ���� ����

    public AudioSource musicSource;  // ����� ����� �ҽ� ����
    public AudioSource sfxSource;    // ����� ����� �ҽ� ����

    // ����� �ɼ�
    public AudioMixer mixer;                   // ����� ����� �ͼ�

    const string MIXER_MUSIC = "MusicVolume";  // ����� Param�� (music)
    const string MIXER_SFX = "SFXVolume";      // ����� Param�� (sfx)

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    public void PlayMusic(string name)
    {  // ����� BGM �Լ� ����
        Sound sound = Array.Find(musicSound, x => x.name == name);  // Array ���ٽ� name�� ã�Ƽ� ��ȯ

        if (sound == null)
        {                  // name���� �� wav�� ���� ��� Log ���
            Debug.Log("Sound Not Found!");
        }
        else
        {
            musicSource.clip = sound.clip;  // ������ ����� �ҽ��� Ŭ���� �ִ´�.
            musicSource.Play();             // �Ϲ� Play ���
        }
    }
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSound, x => x.name == name);  // Array ���ٽ� name�� ã�Ƽ� ��ȯ

        if (sound == null)
        {                  // name���� �� wav�� ���� ��� Log ���
            Debug.Log("Sound Not Found!");
        }
        else
        {
            sfxSource.PlayOneShot(sound.clip);  // �Ϲ� Play ���
        }
    }

}
