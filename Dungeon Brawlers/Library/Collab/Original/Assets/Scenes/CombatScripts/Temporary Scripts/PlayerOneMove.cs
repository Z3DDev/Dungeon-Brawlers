using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMove : MonoBehaviour
{
    public float speed;
    private GameObject cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CombatManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (!cm.GetComponent<CombatManager>().GetInCombat())
        {
            Vector3 pos = transform.position;

            if (Input.GetKey("w"))
            {
                pos.y += speed * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                pos.y -= speed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
            }

            transform.position = pos;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!cm.GetComponent<CombatManager>().GetInCombat() && collision.tag == "Player" && Input.GetKey("e"))
        {
            Debug.Log("Player One Intiates Combat");
            /* UNCOMMENT AFTER TESTING */
            cm.GetComponent<CombatManager>().SetInCombat(true);
            cm.GetComponent<CombatManager>().SetPlayerAttack(1);
        }
    }
}
