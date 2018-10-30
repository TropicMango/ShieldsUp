using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public GameObject pausePanel;
    public Text TitlePanel;
    public Text InfoPanel;

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

    public void displayMessage(float time, string name, string message) {
        message = message.Replace("NEWLINE", "\n");
        StartCoroutine(timedDisplay(time, name, message));
    }

    public IEnumerator timedDisplay (float time, string name, string message) {
        TitlePanel.text = name;
        TitlePanel.enabled = true;
        InfoPanel.text = message;
        InfoPanel.enabled = true;
        yield return new WaitForSeconds(time);
        //InfoPanel.text = "";
        TitlePanel.enabled = false;
        InfoPanel.enabled = false;
    }
}
