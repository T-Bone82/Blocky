using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

    private GameObject pauseObject;

    /*public void Awake()
    {
        pauseObject = GameObject.Find("PausePrefab").GetComponent<GameObject>();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseObject.SetActive(true);
        }
    }*/
}
