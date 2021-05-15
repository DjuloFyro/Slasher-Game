using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToload;

    public GameObject settingsWindow;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToload);
        Time.timeScale = 1f;
    }


    public void SettingButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
