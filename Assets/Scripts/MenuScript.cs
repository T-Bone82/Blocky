using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour {

    private GameObject pauseObject;
    private bool paused = false;

    public void Start () {
        pauseObject = Utilities.findGameObject("PauseMenu");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1;
            }

            pauseObject.SetActive(!paused);
            paused = !paused;
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
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void StartLevel01()
    {
        SceneManager.LoadScene("Level01", LoadSceneMode.Single);
    }

    public void StartNextLevel()
    {
        SceneManager.LoadScene("Level02", LoadSceneMode.Single);
        GameObject endingMenu = Utilities.findGameObject("EndingMenu");
    }

}
