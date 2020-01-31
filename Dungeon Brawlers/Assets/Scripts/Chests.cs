using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour
{
    public GameObject closedChest;
    public GameObject openedChest;

    void Start() {
        closedChest.SetActive(true);
        openedChest.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D collider) {
        closedChest.SetActive(false);
        openedChest.SetActive(true);
    }
}
