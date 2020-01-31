using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {
    
    public Animator anim;

    public Transform atkPoint;
    public float atkRange = 0.5f;
    public LayerMask opponentLayer;

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            Attack();
        }
    }

    void Attack() {
        anim.SetTrigger("Attack");

    }
}
