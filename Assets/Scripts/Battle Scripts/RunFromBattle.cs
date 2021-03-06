﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RunFromBattle : MonoBehaviour
{//this script allows the player to run from battle

    [SerializeField]
    private float runnningChance;
    private bool boss;
    private GameObject[] enemyUnits;
    private GameManager1 gameManager;
    private new AudioSource audio;

    private void Start()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
        boss = false; //set false as default
        enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        gameManager = FindObjectOfType<GameManager1>();
        foreach (GameObject enemyUnit in enemyUnits)
        { //check if boss is present
            if (enemyUnit.name.Contains("BOSS"))
            {//BOSS found!
                boss = true;
                Debug.Log("BOSS Found");
            }
        }
    }
    public void tryRunning()
    {
        //play audio
        if (audio != null)
        {
            audio.Play();
        }


        float randomNumber = Random.value;

        //if there is a boss you cannot escape
        //check if they are able to run from battle by using a random number
        if (boss == false && randomNumber < this.runnningChance)
        {

            gameManager = FindObjectOfType<GameManager1>();
            if (gameManager != null)
            {
                gameManager.UpdateLevelScene();
            }
            //delete the enemies
            enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
            foreach (GameObject enemyUnit in enemyUnits)
            {
                Destroy(enemyUnit);
            }
            
            GameObject turnSystem = GameObject.Find("TurnSystem");
            if (turnSystem != null)
            {
                turnSystem.GetComponent<TurnSystem1>().revivePlayers();
                turnSystem.GetComponent<TurnSystem1>().controlPlayers();
            }

            //if you escape delete the battle camera
            GameObject gameCamera = GameObject.Find("Main Camera");
            Destroy(gameCamera);


        }
        else
        {
            //next turn
            GameObject turnSystem = GameObject.Find("TurnSystem");
            // turnSystem.GetComponent<TurnSystem1>().IncreaseTurn();
            GameObject.Find("PlayerParty").GetComponent<SelectUnit>().setMenus();
            turnSystem.GetComponent<TurnSystem1>().nextTurn();

            

        }

    }
}
