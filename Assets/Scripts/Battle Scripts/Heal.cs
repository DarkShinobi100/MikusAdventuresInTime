﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Heal : MonoBehaviour
{

    [SerializeField]
    private float HP;

    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => addCallback());
    }

    private void addCallback()
    {
        //find the turn system
        GameObject turnSystem = GameObject.Find("TurnSystem");
        //get the current player
        GameObject currentPlayer = turnSystem.GetComponent<TurnSystem1>().GetCurrentPlayer();
        //heal that player
        currentPlayer.GetComponent<UnitStats>().health += HP;

        //if health is greater than 100 cap at 100
        if (currentPlayer.GetComponent<UnitStats>().health >= 1000)
        {
            currentPlayer.GetComponent<UnitStats>().health = 100;
        }

        GameObject.Find("PlayerParty").GetComponent<SelectUnit>().setMenus();
        
        GameObject.Find("TurnSystem").GetComponent<TurnSystem1>().nextTurn();
    }

}
