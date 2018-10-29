using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public GameObject pausePanel;
    public Text TextPanel;

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

    public void displayMessage(float time, string message) {
        StartCoroutine(timedDisplay(time, message));
    }

    public IEnumerator timedDisplay (float time, string message) {
        TextPanel.text = message;
        TextPanel.enabled = true;
        yield return new WaitForSeconds(time);
        TextPanel.text = "";
        TextPanel.enabled = false;
    }
}
