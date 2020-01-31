using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour {
    public int keyValue = 1;

    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.name == "Player 1") {
            //playerOne.key += keyValue;
        }

        else if(collider.gameObject.name == "Player 2") {
            //playerTwo.key += keyValue;
        }
    }
    void Start() {
        /* PlayerOneMove playerOne = GetComponent<PlayerOneMove>();
        PlayerTwoMove playerTwo = GetComponent<PlayerTwoMove>(); */
    }
}
