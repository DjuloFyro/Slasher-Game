using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    public bool playerIsDead;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("trop d'instance gameOver samer");
            return;
        }
        instance = this;

        playerIsDead = false;
    }


    public void OnPlayerDeath()
    {
        playerIsDead = true;

        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        //Health.instance.Respawn();
        gameOverUI.SetActive(false);
        playerIsDead = false;


    }

    public void MainMenuButton()
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
