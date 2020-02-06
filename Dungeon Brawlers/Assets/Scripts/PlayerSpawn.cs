using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : PlayerController {
    public GameObject playerOneSpawn;
    public GameObject playerTwoSpawn;

    public float respawnDelay;

    void OnSpawn() {
        if(playerid == 1) {

        }
    }

    void OnRespawn() {
        StartCoroutine("RespawnPlayer");
    }

    /* public IEnumerator RespawnPlayer() {
        if(playerid == 1) {
            Instantiate(Player1.transform.position, Player1.transform.rotation);
            Player1.enabled = false;
            Player1.GetComponent<Renderer>().enabled = false;

            yield return new WaitForSeconds(respawnDelay);
            Player1.transform.position = playerOneSpawn.transform.position;
            Player1.enabled = true;
            Player1.GetComponent<Renderer>().enabled = true;
            PlayerController.isDead = false;
            
            Instantiate(playerOneSpawn.transform.position, playerOneSpawn.transform.rotation); 
        }
        
    } */
}
