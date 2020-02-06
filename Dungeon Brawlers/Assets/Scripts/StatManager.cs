using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatManager : PlayerController {
    //<-------------------------------- Player One Statistics -------------------------------->
    public int baseOneHealth, playerOneH;      //Base Health Value, Player Health Value, Updated Player Health Value
    public int playerOneAtk;                   //Base Attack Value, Player Attack Value, Updated Player Attack Value
    public int playerOneDef;                   //Base Defense Value, Player Defense Value, Updated Player Defense Value
    public bool playerOneIsDead;               //Player One Boolean for Death

    //<-------------------------------- Player Two Statistics -------------------------------->
    public int baseTwoHealth, playerTwoH;      //Base Health Value, Player Health Value, Updated Player Health Value
    public int baseTwoAtk, playerTwoAtk;       //Base Attack Value, Player Attack Value, Updated Player Attack Value
    public int baseTwoDef, playerTwoDef;       //Base Defense Value, Player Defense Value, Updated Player Defense Value
    public bool playerTwoIsDead;               //Player Two Boolean for Death

    void Awake() {
        //Set Both Players Health to the Base Stat
        playerOneH = baseOneHealth;
        playerTwoH = baseTwoHealth;

        //Update the TextMeshPro Objects on the Canvas
        playerOneHealth.text = "Health: " + playerOneH.ToString() + "/" + baseOneHealth.ToString();     //Player One Health 
        playerTwoHealth.text = "Health: " + playerTwoH.ToString() + "/" + baseTwoHealth.ToString();     //Player Two Health

        playerOneAttack.text = "Atk: " + playerOneAtk.ToString();                                       //Player One Attack
        playerTwoAttack.text = "Atk: " + playerTwoAtk.ToString();                                       //Player Two Attack

        playerOneDefense.text = "Def: " + playerOneDef.ToString();                                      //Player One Defense
        playerTwoDefense.text = "Def: " + playerTwoDef.ToString();                                      //Player Two Defense
    }

    //When an Item is picked up to Increase the Player Health, it will increase BOTH the Base Stat and the Current Health Value
    //The function will then update the TextMeshPro Object, and displayed the Increase with a Value Marker next to the variable
    void IncreaseHealth(int addValue) {
        if(Player1.playerid == 1) {
            baseOneHealth = baseOneHealth + addValue;
            playerOneH = playerOneH + addValue;


            playerOneHealth.text = "Health: " + playerOneH.ToString() + "/" + baseOneHealth.ToString();
            p1UpdateHealth.text = "+" + addValue.ToString();
        }
        else if(Player2.playerid == 2) {
            baseTwoHealth = baseTwoHealth + addValue;
            playerTwoH = playerTwoH + addValue;

            playerTwoHealth.text = "Health: " + playerTwoH.ToString() + "/" + baseTwoHealth.ToString();
            p2UpdateHealth.text = "+" + addValue.ToString();
        }
    }

    //When an Item is picked up to Increase the Player Attack, it will increase the current Attack Stat
    //The function will then update the TextMeshPro Object and display the Increase with a Value Marker next to the variable
    void IncreaseAtk(int addValue) {
        if(Player1.playerid == 1) {
            playerOneAtk = playerOneAtk + addValue;

            playerOneAttack.text = "Atk: " + playerOneAtk.ToString(); 
            p1UpdateAtk.text = "+" + addValue.ToString();
        }
        else if(Player2.playerid == 2) {
            playerTwoAtk = playerTwoAtk + addValue;

            playerTwoAttack.text = "Atk: " + playerTwoAtk.ToString(); 
            p2UpdateAtk.text = "+" + addValue.ToString();
        }
    }

    //When an Item is picked up to Increase the Player Defense, it will increase the current Defense Stat
    //The function will then update the TextMeshPro Object and display the Increase with a Value Marker next to the variable
    void IncreaseDef(int addValue) {
        if(Player1.playerid == 1) {
            playerOneDef = playerOneDef + addValue;

            playerOneDefense.text = "Def: " + playerOneDef.ToString();
            p1UpdateDef.text = "+" + addValue.ToString();
        }
        else if(Player2.playerid == 2) {
            playerTwoDef = playerTwoDef + addValue;

            playerTwoDefense.text = "Def: " + playerTwoDef.ToString(); 
            p2UpdateDef.text = "+" + addValue.ToString();
        }
    }

    //When the Player is hit with an Attack, the function will take in the Attak Stat of the Oppossing Player and deal it as Damage
    //If the Players Health hits Zero or goes below, a Boolean will hit triggering a Death
    //A Player Death will call the Respawn Function in PlayerSpawn and reset the Player's Stats and Location
    void HurtPlayer(int damageGiven) {
        if(Player1.playerid == 1) {
            playerOneH = playerOneH - damageGiven;

            if(playerOneH < 0) {
                playerOneH = 0;
                playerOneHealth.text = "Health: " + playerOneH.ToString() + "/" + baseOneHealth.ToString();

                //ADD RESPAWN FUNCTION CALL
            }
            else {
                playerOneHealth.text = "Health: " + playerOneH.ToString() + "/" + baseOneHealth.ToString();
                p1UpdateHealth.text = "-" + damageGiven.ToString();
            }
        }
        else if(Player2.playerid == 2) {
            playerTwoH = playerTwoH - damageGiven;

            if(playerTwoH < 0) {
                playerTwoH = 0;
                playerTwoHealth.text = "Health: " + playerTwoH.ToString() + "/" + baseTwoHealth.ToString();

                //ADD RESPAWN FUNCTION CALL
            }
            else {
                playerTwoHealth.text = "Health: " + playerTwoH.ToString() + "/" + baseTwoHealth.ToString();
                p2UpdateHealth.text = "-" + damageGiven.ToString();
            }
        }
    }

    //When the Player Heals, the function will check to see if the Player Health is already more than or equal to the Base Health
    //If it does, it will set the Player Health equal to the Base Health (as that is it's maximum)
    //This check will occur again when adding Health to the player, it it now equals more than the Base Health it will set it to MAX
    //Otherwise, it will hit the second else statement and add the amount of Health Given and display that amount on the UI
    void HealPlayer(int healthGiven) {
        if(Player1.playerid == 1) {
            if((playerOneH > baseOneHealth) || (playerOneH == baseOneHealth)) {
                playerOneH = baseOneHealth;

                playerOneHealth.text = "Health: " + playerOneH.ToString() + "/" + baseOneHealth.ToString();
                p1UpdateHealth.text = "MAX";
            }
            else {
                playerOneH = playerOneH + healthGiven;

                if((playerOneH > baseOneHealth) || (playerOneH == baseOneHealth)) {
                    playerOneH = baseOneHealth;

                    playerOneHealth.text = "Health: " + playerOneH.ToString() + "/" + baseOneHealth.ToString();
                    p1UpdateHealth.text = "MAX";
                }
                else {
                    playerOneHealth.text = "Health: " + playerOneH.ToString() + "/" + baseOneHealth.ToString();
                    p1UpdateHealth.text = "+" + healthGiven.ToString();
                }
            }
        }
        else if(Player2.playerid == 2) {
            if((playerTwoH > baseTwoHealth) || (playerTwoH == baseTwoHealth)) {
                playerTwoH = baseTwoHealth;

                playerTwoHealth.text = "Health: " + playerTwoH.ToString() + "/" + baseTwoHealth.ToString();
                p2UpdateHealth.text = "MAX";
            }
            else {
                playerTwoH = playerTwoH + healthGiven;

                if((playerOneH > baseOneHealth) || (playerOneH == baseOneHealth)) {
                    playerTwoH = baseTwoHealth;

                    playerTwoHealth.text = "Health: " + playerTwoH.ToString() + "/" + baseTwoHealth.ToString();
                    p2UpdateHealth.text = "MAX";
                }
                else {
                    playerTwoHealth.text = "Health: " + playerTwoH.ToString() + "/" + baseTwoHealth.ToString();
                    p2UpdateHealth.text = "+" + healthGiven.ToString();
                }
            }
        }
    }
}
