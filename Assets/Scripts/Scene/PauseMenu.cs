using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPause;
    private void Awake()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPause = false;
    }

    private void Update()
    {
        Pause();
    }


    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            isPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            isPause = false;
        }
    }
}
