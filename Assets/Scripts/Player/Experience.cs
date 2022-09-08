using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    public Image experienceImage;
    public Text lvlText;
    public int currentLvl;
    public float currenExperience;
    public float expToNextLevel;

    public static Experience instancie;

    private void Awake()
    {
        if (instancie == null)
        {
            instancie = this;
        }
    }
    private void Start()
    {
        PlayerHealth.instancie.maxHealth = PlayerPrefs.GetFloat("MaxHealth",
            PlayerHealth.instancie.maxHealth);
        currenExperience = PlayerPrefs.GetFloat("Experience",0);
        expToNextLevel = PlayerPrefs.GetFloat("ExperienceToNextLevel",expToNextLevel);
        currentLvl = PlayerPrefs.GetInt("CurrentLevel",1);
        lvlText.text = currentLvl.ToString();
        experienceImage.fillAmount = currenExperience / expToNextLevel;
    }
    public void ExpModifier(float experience)
    {
        currenExperience += experience;
        if (currenExperience>=expToNextLevel)
        {
            expToNextLevel *= 2;
            currenExperience = 0;
            PlayerHealth.instancie.maxHealth += 20;
            SubWeapons.instancie.subweaponsMax += 10;
            currentLvl += 1;
            AudioManager.instance.PlayAudio(AudioManager.instance.levelUp);
            lvlText.text = currentLvl.ToString();
        }
    

        experienceImage.fillAmount = currenExperience / expToNextLevel;

    }

    public void DataToSave()
    {
        DataManager.instance.MaxHealthData(PlayerHealth.instancie.maxHealth);
        DataManager.instance.ExperienceData(currenExperience);
        DataManager.instance.ExperienceToNextLevelData(expToNextLevel);
        DataManager.instance.CurrentLevelData(currentLvl);
        PlayerHealth.instancie.maxHealth = PlayerPrefs.GetFloat("MaxHealth");
        currenExperience = PlayerPrefs.GetFloat("Experience");
        expToNextLevel = PlayerPrefs.GetFloat("ExperienceToNextLevel");
        currentLvl = PlayerPrefs.GetInt("CurrentLevel");
    }
}
