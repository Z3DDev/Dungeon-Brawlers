using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {
    
    public Animator anim;

    public Transform atkPoint;
    public float atkRange = 0.5f;
    public LayerMask opponentLayer;

    private GameObject cm;
    public PlayerMovement player;

    void Awake() {
        cm = GameObject.FindGameObjectWithTag("CombatManager");
        player = GetComponent<PlayerMovement>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            Attack();
        }
    }

    void Attack() {
        if(player.playerid == 1) {
            anim.SetTrigger("P1_Attack");
        }
        else if(player.playerid == 2) {
            anim.SetTrigger("P2_Attack");
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if ((!cm.GetComponent<CombatManager>().GetInCombat() && collision.tag == "Player" && Input.GetKey("e")) || (!cm.GetComponent<CombatManager>().GetInCombat() && collision.tag == "Player" && Input.GetKeyUp(KeyCode.Keypad7))) {
            cm.GetComponent<CombatManager>().SetInCombat(true);
            cm.GetComponent<CombatManager>().SetPlayerAttack(1);
        }
    }
}
