using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance!=null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void MusicData(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume",value);
    }
    public void EfectData(float value)
    {
        PlayerPrefs.SetFloat("EfectVolume", value);
    }

    public void ExperienceData(float value)
    {
        PlayerPrefs.SetFloat("Experience", value);
    }
    public void ExperienceToNextLevelData(float value)
    {
        PlayerPrefs.SetFloat("ExperienceToNextLevel", value);
    }
    public void CurrentLevelData(int value)
    {
        PlayerPrefs.SetInt("CurrentLevel", value);
    }

    public void SubWeaponsCountData(float value)
    {
        PlayerPrefs.SetFloat("SubWeaponsCount", value);
    }
    public void SubweaponsMaxData(float value)
    {
        PlayerPrefs.SetFloat("SubweaponsMax", value);
    }

    public void MaxHealthData(float value)
    {
        PlayerPrefs.SetFloat("MaxHealth", value);

    }
    public void BankData(float value)
    {
        PlayerPrefs.SetFloat("Bank", value);
    }
}
