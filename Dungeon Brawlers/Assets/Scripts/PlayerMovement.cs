using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Player Movement
    public int playerid;                //Each Player is assigned an ID to distinguish their controls
    public float mvSpeed = 5f;          //Default Player Move Speed
    public Rigidbody2D rb;              //Instance of the Rigidbody Object on the Player
    public Animator anim;               //Instance of the Animator
    Vector2 movement;                   //Vector in which the Player moves

    //Player Combat
    public Transform atkPoint;          //Attack Point for how far the Player can strike
    public float atkRange = 0.5f;       //Range at which the Player can strike
    public LayerMask opponentLayer;     //Layer Mask to distinguish what the Player can hit

    void Awake() {
        rb = GetComponent<Rigidbody2D>();   //On Awake, grab the Rigidbody2D component
        anim = GetComponent<Animator>();    //On Awake, grab the Animator component
    }

    void Update() {

        //Player One Controls designated by Player ID
        if(playerid == 1) {
            movement.x = Input.GetAxisRaw("P1_Horizontal");
            movement.y = Input.GetAxisRaw("P1_Vertical");

            anim.SetFloat("P1_Horizontal", movement.x);
            anim.SetFloat("P1_Vertical", movement.y);
            anim.SetFloat("Speed", movement.sqrMagnitude);

            if(Input.GetKeyDown(KeyCode.E)) {
                Attack();
            }
        }
        //Player Two Controls designated by Player ID
        else if(playerid == 2) {
            movement.x = Input.GetAxisRaw("P2_Horizontal");
            movement.y = Input.GetAxisRaw("P2_Vertical");

            anim.SetFloat("P2_Horizontal", movement.x);
            anim.SetFloat("P2_Vertical", movement.y);
            anim.SetFloat("Speed", movement.sqrMagnitude);

            if(Input.GetKeyDown(KeyCode.Keypad9)) {
                Attack();
            }
        }
    }

    //Function used to specifically carry out Attack
    void Attack() {
        if(playerid == 1) {
            anim.SetTrigger("P1_Attack");
        }

        else if(playerid == 2) {
            anim.SetTrigger("P2_Attack");
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * mvSpeed * Time.fixedDeltaTime);
    }
}
