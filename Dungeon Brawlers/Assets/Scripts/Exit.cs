using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider) {
        /* if(collider.gameObject.name == "PlayerOne" && playerOne.key == 1) {
            
        }

        else if(collider.gameObject.name == "PlayerTwo" && PlayerTwoMove.key == 1) {
            playerTwo.key += keyValue;
        } */
    }

    void Start() {
        PlayerOneMove playerOne = GetComponent<PlayerOneMove>();
        PlayerTwoMove playerTwo = GetComponent<PlayerTwoMove>();
    }
}
