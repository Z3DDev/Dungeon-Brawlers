using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMove : MonoBehaviour {
    public Rigidbody2D rb;
    public float mvSpeed;
    private GameObject cm;
    Vector2 movement;
    public Animator anim;

    // Start is called before the first frame update
    void Start() {
        cm = GameObject.FindGameObjectWithTag("CombatManager");
    }

    // Update is called once per frame
    void Update() {
        if (!cm.GetComponent<CombatManager>().GetInCombat()) {
            //Vector3 pos = transform.position;
            Vector2 movement = transform.position;

            if (Input.GetKey("w")) {
                movement.y += mvSpeed * Time.deltaTime;
            }
            if (Input.GetKey("s")) {
                movement.y -= mvSpeed * Time.deltaTime;
            }
            if (Input.GetKey("d")) {
                movement.x += mvSpeed * Time.deltaTime;
            }
            if (Input.GetKey("a")) {
                movement.x -= mvSpeed * Time.deltaTime;
            }

            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * mvSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (!cm.GetComponent<CombatManager>().GetInCombat() && collision.tag == "Player" && Input.GetKey("e")) {
            Debug.Log("Player One Intiates Combat");
            /* UNCOMMENT AFTER TESTING */
            cm.GetComponent<CombatManager>().SetInCombat(true);
            cm.GetComponent<CombatManager>().SetPlayerAttack(1);
        }
    }
}
