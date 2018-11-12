using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
            //QuitGame();
        //}
    }

    public void StartGame() {
		SceneManager.LoadScene("Level01");
    }

	public void QuitGame() {
		Application.Quit();
	}
}