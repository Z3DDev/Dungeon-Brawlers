using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoMove : MonoBehaviour
{
    public float speed;
    private bool inRange;
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
            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Keypad8))
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Keypad5))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!cm.GetComponent<CombatManager>().GetInCombat() && collision.tag == "Player" && Input.GetKeyUp(KeyCode.Keypad7))
        {
            Debug.Log("The Lesser Player Intiates Combat");
            /* UNCOMMENT AFTER TESTING */
            cm.GetComponent<CombatManager>().SetInCombat(true);
            cm.GetComponent<CombatManager>().SetPlayerAttack(2);
        }
    }
}
