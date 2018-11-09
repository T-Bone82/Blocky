using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

    private GameObject pauseObject;
    private bool paused = false;

    public void Start () {
        Object[] objs = Resources.FindObjectsOfTypeAll(typeof(GameObject));

        foreach (Object obj in objs)
        {
            if (obj.name == "PausePrefab")
            {
                pauseObject = (GameObject) obj;
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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0f;
            } else
            {
                Time.timeScale = 1;
            }
            
            pauseObject.SetActive(!paused);
            paused = !paused;
        }
    }
}
