using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallPauseScene : MonoBehaviour {

    private GameObject pauseObject;

    public void Awake()
    {
        pauseObject = GameObject.Find("PausePrefab").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseObject.SetActive(true);
        }	
	}
}
