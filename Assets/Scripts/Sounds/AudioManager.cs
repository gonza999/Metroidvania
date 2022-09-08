using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer music;
    public AudioMixer efects;
    public AudioSource musicBackground;
    public AudioSource hit;
    public AudioSource enemyDead;
    public AudioSource money;
    public AudioSource arrow;
    public AudioSource fire;
    public AudioSource levelUp;
    public AudioSource playerDead;
    public AudioSource playerDamage;
    public AudioSource mainMenu;
    public AudioSource dead;
    [Range (-80,10)]
    public float masterVol;
    [Range(-80, 10)]
    public float efectsVol;

    public Slider masterSlider;
    public Slider efectsSlider;
    public static AudioManager instance;

    private void Start()
    {
        PlayAudio(musicBackground);
        masterSlider.value = PlayerPrefs.GetFloat("MusicVolume",0);
        efectsSlider.value = PlayerPrefs.GetFloat("EfectVolume", 0);
    }

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }

    public void MasterVolume()
    {
        DataManager.instance.MusicData(masterSlider.value);
        music.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MusicVolume"));
    }

    public void EfectsVolume()
    {
        DataManager.instance.MusicData(efectsSlider.value);
        efects.SetFloat("EfectsVolume", PlayerPrefs.GetFloat("EfectVolume"));
    }

}
