using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animatorSettings;
    public GameObject settings;

    private void Start()
    {
        settings.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name=="MainMenu")
        {
            AudioManager.instance.musicBackground.Stop();
            AudioManager.instance.PlayAudio(AudioManager.instance.mainMenu);

        }
        Time.timeScale = 1;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowSettings()
    {
        settings.SetActive(true);
        animatorSettings.SetBool("Show", true);
    }
    public void HireSettings()
    {
        animatorSettings.SetBool("Show", false);
    }
}
