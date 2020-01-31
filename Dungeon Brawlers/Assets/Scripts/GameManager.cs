using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    //public BoardManager boardScript;

    public bool countdownDone = false;
	public GameObject CountDown;
    //private int level = 3;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
        else if(instance != null) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        /* boardScript = GetComponent<BoardManager>();
        InitGame(); */
    }

    /* void InitGame() {
        boardScript.SetupScene(level);
    } */

	void Update () {
		if(countdownDone) {
			CountDown.SetActive(false);
		}
	}
}
