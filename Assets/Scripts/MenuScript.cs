using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    private GameObject pauseObject;
    private GameObject txtEndOfGame;
    private GameObject btnNextLevelButton;
    private GameObject backButton;

    private bool paused = false;

    public void Start () {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            backButton = Utilities.FindGameObject("BackButton");
        }
        else
        { 
            pauseObject = Utilities.FindGameObject("PauseMenu");
            txtEndOfGame = Utilities.FindGameObject("TextEndOfGame");
            btnNextLevelButton = Utilities.FindGameObject("NextLevelButton");
            
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextLevel >= SceneManager.sceneCountInBuildSettings)
            {
                txtEndOfGame.SetActive(true);
                btnNextLevelButton.SetActive(false);
            }
        }
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (backButton != null && backButton.active)
                {
                    backButton.GetComponent<Button>().onClick.Invoke();
                }
            }
        } else {
            if (Input.GetButtonDown("Cancel"))
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0f;
                }
                else
                {
                    Time.timeScale = 1;
                }
                if (SceneManager.GetActiveScene().name != "Menu")
                {
                    pauseObject.SetActive(!paused);
                    paused = !paused;
                }
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseObject.SetActive(!paused);
        paused = !paused;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GotoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void StartLevel01()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void StartNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }

}
