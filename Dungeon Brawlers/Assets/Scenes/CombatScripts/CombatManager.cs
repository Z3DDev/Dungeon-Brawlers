using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public RectTransform combatPanel;
    public GameObject playerOne;
    public GameObject playerTwo;

    //Player One Menu Items
    public GameObject playerOneMenuGen;
    public GameObject playerOneHealth;
    public GameObject playerOneBasicMenu;
    public GameObject playerOneFightMenu;

    //Player Two Menu Items
    public GameObject playerTwoMenuGen;
    public GameObject playerTwoHealth;
    public GameObject playerTwoBasicMenu;
    public GameObject playerTwoFightMenu;

    //GameOver Screens
    public GameObject playerOneWins;
    public GameObject playerTwoWins;

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
        UpdateHealth();
    }


    private void MenuHandler()
    {
        int attackDamage = 0;
        int runChance = 0;

        //DETERMINES WHO ATTACKED FIRST
        if (inCombat)
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

        //DETERMINES IF THEY ATTACK OR RUN
        if (inCombat && playerOneBasicMenu.activeSelf && playerOneMenuGen.activeSelf)
        {
            if (Input.GetKey("a"))
            {
                Debug.Log("A was selected");
                playerOneBasicMenu.SetActive(false);
                playerOneFightMenu.SetActive(true);
                attackDamage = Random.Range(0, 20);
                playerTwo.GetComponent<PlayerHealth>().health -= attackDamage;
                if (playerTwo.GetComponent<PlayerHealth>().health > 0)
                {
                    UpdateHealth();
                }
                else
                {
                    Debug.Log("Player One Wins");
                    ShowWinner(playerOne.GetComponent<PlayerHealth>().health, playerTwo.GetComponent<PlayerHealth>().health);
                }
            }
            else if (Input.GetKey("d"))
            {
                Debug.Log("D was selected");
                runChance = Random.Range(1, 10);
                if (runChance > 5)
                {
                    inCombat = false;
                }
            }
        }
        else if (inCombat && playerTwoBasicMenu.activeSelf && playerTwoMenuGen.activeSelf)
        {
            if (Input.GetKey(KeyCode.Keypad4))
            {
                Debug.Log("4 was selected");
                playerTwoBasicMenu.SetActive(false);
                playerTwoFightMenu.SetActive(true);
                attackDamage = Random.Range(0, 20);
                playerOne.GetComponent<PlayerHealth>().health -= attackDamage;
                if (playerOne.GetComponent<PlayerHealth>().health > 0)
                {
                    UpdateHealth();
                }
                else
                {
                    Debug.Log("Player Two Wins");
                    ShowWinner(playerOne.GetComponent<PlayerHealth>().health, playerTwo.GetComponent<PlayerHealth>().health);
                }
            }
            else if (Input.GetKey(KeyCode.Keypad6))
            {
                Debug.Log("6 was selected");
                inCombat = false;
            }
        }

        //ENDS THE PLAYER'S TURN AND PASSES CONTROL TO THE NEXT PLAYER
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

        //RESETS THE PANELS AFTER THE BATTLE HAS ENDED
        if (!inCombat)
        {
            ResetCombatMenu();
            combatPanel.gameObject.SetActive(false);
        }
    }

    //RESETS ALL OF THE MENUS TO THE STATES THEY NEED TO BE IN
    private void ResetCombatMenu()
    {
        playerOneFightMenu.SetActive(false);
        playerOneBasicMenu.SetActive(true);
        playerOneMenuGen.SetActive(false);

        playerTwoFightMenu.SetActive(false);
        playerTwoBasicMenu.SetActive(true);
        playerTwoMenuGen.SetActive(false);
    }

    //UPDATES THE PLAYER'S HEALTH AFTER BEING ATTACKED
    private void UpdateHealth()
    {
        playerOneHealth.GetComponent<UnityEngine.UI.Text>().text = "Health: " + playerOne.GetComponent<PlayerHealth>().health.ToString();
        playerTwoHealth.GetComponent<UnityEngine.UI.Text>().text = "Health: " + playerTwo.GetComponent<PlayerHealth>().health.ToString();
    }

    //DISPLAYS WHEN A PLAYER HAS WON
    private void ShowWinner(int healthOne, int healthTwo)
    {
        if (healthTwo <= 0)
        {
            playerOneWins.SetActive(true);
        }
        else if (healthOne <= 0)
        {
            playerTwoWins.SetActive(true);
        }
        else
        {
            Debug.Log("Something went wrong with displaying a winner.");
        }
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
