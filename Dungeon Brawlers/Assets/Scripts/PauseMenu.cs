using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public string mainMenu;
	public string restartLevel;

    public bool isPaused = false;

    public GameObject pauseMenuCanvas;
    public GameObject gameTimer;

	void Awake() {
		pauseMenuCanvas.SetActive(false);
	}

    void Update() {
		if(isPaused) {
			pauseMenuCanvas.SetActive(true);
            gameTimer.SetActive(false);
			Time.timeScale = 0f;
		}
		else {
			pauseMenuCanvas.SetActive(false);
            gameTimer.SetActive(true);
			Time.timeScale = 1f;
		}

        if(Input.GetKey(KeyCode.Escape)) {
            isPaused = !isPaused;
        }
    }

    public void Resume() {
        isPaused = false;
    }

    public void Restart() {
        SceneManager.LoadScene(restartLevel, LoadSceneMode.Single);
    }

    public void QuitGame() {
        SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
    }
}