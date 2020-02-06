using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour {
    //<-------------------------------- Player -------------------------------->
    public PlayerController Player1;
    public PlayerController Player2;

    public TextMeshProUGUI playerOneName, playerOneHealth, playerOneAttack, playerOneDefense;
    public TextMeshProUGUI playerTwoName, playerTwoHealth, playerTwoAttack, playerTwoDefense;
    public TextMeshProUGUI p1UpdateHealth, p1UpdateAtk, p1UpdateDef;
    public TextMeshProUGUI p2UpdateHealth, p2UpdateAtk, p2UpdateDef;

    //<-------------------------------- Player Movement -------------------------------->
    public int playerid;                //Each Player is assigned an ID to distinguish their controls
    private float mvSpeed = 5f;          //Default Player Move Speed
    private Rigidbody2D rb;              //Instance of the Rigidbody Object on the Player
    private Animator anim;               //Instance of the Animator
    Vector2 movement;                   //Vector in which the Player moves

    //<-------------------------------- Player Combat -------------------------------->
    private Transform atkPoint;          //Attack Point for how far the Player can strike
    private float atkRange = 0.5f;       //Range at which the Player can strike
    private LayerMask opponentLayer;     //Layer Mask to distinguish what the Player can hit

    void Awake() {
        rb = GetComponent<Rigidbody2D>();   //On Awake, grab the Rigidbody2D component
        anim = GetComponent<Animator>();    //On Awake, grab the Animator component

        if(playerid == 1) {
            Player1 = GetComponent<PlayerController>();
        }
        else if(playerid == 2) {
            Player2 = GetComponent<PlayerController>();
        }
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