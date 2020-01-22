using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public RectTransform combatPanel;

    //Player One Menu Items
    public GameObject playerOneMenuGen;
    public GameObject playerOneBasicMenu;
    public GameObject playerOneFightMenu;

    //Player Two Menu Items
    public GameObject playerTwoMenuGen;
    public GameObject playerTwoBasicMenu;
    public GameObject playerTwoFightMenu;

    private bool inCombat;
    private int playerAttack;

    //TODO: Will be used in simultaneous Attack/Defense Actions
    private bool playerOneConfirm;
    private bool playerTwoConfirm;

    // Start is called before the first frame update
    void Start()
    {
        inCombat = false;
        playerAttack = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MenuHandler();
    }


    private void MenuHandler()
    {
        if(inCombat)
        {
            combatPanel.gameObject.SetActive(true);

            if (playerAttack == 1)
            {
                playerTwoMenuGen.SetActive(false);
                playerOneMenuGen.SetActive(true);
                
            }
            else if (playerAttack == 2)
            {
                playerOneMenuGen.SetActive(false);
                playerTwoMenuGen.SetActive(true);
            }
            else
            {
                Debug.Log("Error determining who striked first.");
            }
        }


        if (inCombat && playerOneBasicMenu.activeSelf && playerOneMenuGen.activeSelf)
        {
            if (Input.GetKey("a"))
            {
                Debug.Log("A was selected");
                playerOneBasicMenu.SetActive(false);
                playerOneFightMenu.SetActive(true);
            }
            else if (Input.GetKey("d"))
            {
                Debug.Log("D was selected");
                inCombat = false;
            }
        }
        else if (inCombat && playerTwoBasicMenu.activeSelf && playerTwoMenuGen.activeSelf)
        {
            if (Input.GetKey(KeyCode.Keypad4))
            {
                Debug.Log("4 was selected");
                playerTwoBasicMenu.SetActive(false);
                playerTwoFightMenu.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.Keypad6))
            {
                Debug.Log("6 was selected");
                inCombat = false;
            }
        }


        if (inCombat && playerOneFightMenu.activeSelf)
        {
            playerAttack = 2;
            playerOneFightMenu.SetActive(false);
            playerOneBasicMenu.SetActive(true);
        }
        else if (inCombat && playerTwoFightMenu.activeSelf)
        {
            playerAttack = 1;
            playerTwoFightMenu.SetActive(false);
            playerTwoBasicMenu.SetActive(true);
        }


        if (!inCombat)
        {
            ResetCombatMenu();
            combatPanel.gameObject.SetActive(false);
        }
    }

    private void ResetCombatMenu()
    {
        playerOneFightMenu.SetActive(false);
        playerOneBasicMenu.SetActive(true);
        playerOneMenuGen.SetActive(false);

        playerTwoFightMenu.SetActive(false);
        playerTwoBasicMenu.SetActive(true);
        playerTwoMenuGen.SetActive(false);
    }


    //GETTERS AND SETTERS

    public bool GetInCombat()
    {
        return inCombat;
    }

    public void SetInCombat(bool newValue)
    {
        inCombat = newValue;
    }

    public int GetPlayerAttack()
    {
        return playerAttack;
    }

    public void SetPlayerAttack(int newValue)
    {
        playerAttack = newValue;
    }
}
