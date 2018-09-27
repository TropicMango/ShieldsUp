using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public GameObject pausePanel;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log(pausePanel.activeInHierarchy);
            if (!pausePanel.activeInHierarchy) {
                PauseGame();
            }else if (pausePanel.activeInHierarchy) {
                ContinueGame();
            }
        }
    }

    private void PauseGame() {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void ContinueGame() {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
