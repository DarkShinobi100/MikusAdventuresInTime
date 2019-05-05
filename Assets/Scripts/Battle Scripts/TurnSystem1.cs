using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TurnSystem1 : MonoBehaviour
{

    private List<UnitStatFunctions> unitsStats;

    private GameObject playerParty, CurrentPlayer;

    public GameObject enemyEncounter;


    [SerializeField]
    private GameObject actionsMenu, enemyUnitsMenu, gameOverMenu;

    [SerializeField]
    private AudioSource BGM;
    
    //------------------------------------
    //Traditional system
    //-------------------------------------
    //[SerializeField]
    //private GameObject[] Units = new GameObject[4];
    //[SerializeField]
    //private int turnNumber = 0;

    //private void Start()
    //{
    //    //make a clone of player party in this scene
    //    this.playerParty = GameObject.Find("PlayerParty");

    //    StartParty();

    //    //create a list of ACTIVE player units
    //    GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

    //    //find enemies
    //    GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");

    //     Units[0] = playerUnits[0]; //Miku
    //     Units[1] = enemyUnits[0]; //1st enemy
    //     Units[2] = playerUnits[1]; //Miku's friend
    //     Units[3] = enemyUnits[1]; //1st enemy

    //        this.actionsMenu.SetActive(false);
    //        this.enemyUnitsMenu.SetActive(false);
    //        this.gameOverMenu.SetActive(false);

    //    this.nextTurn();

    //}
    //public void nextTurn()
    //{
    //    //check for win requirements
    //    GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
    //    if (remainingEnemyUnits.Length == 0)
    //    {
    //        this.enemyEncounter.GetComponent<CollectReward>().collectReward();
    //        //no enemies left
    //        //unload current level
    //        BGM.Stop();

    //        //Re-enable the disabled/unconscious party members
    //        revivePlayers();
    //        controlPlayers();
    //        GameManager1 gameManager = FindObjectOfType<GameManager1>();
    //        gameManager.UpdateLevelScene();

    //    }

    //    //check for lose requirements
    //    GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
    //    if (remainingPlayerUnits.Length == 0)
    //    {

    //        // game Over
    //        if (gameOverMenu != null)
    //        {
    //            //TODO: play GameOver SFX
    //            actionsMenu.SetActive(false);
    //            gameOverMenu.SetActive(true);
    //        }
    //    }

    //    //check whose turn
    //    if (turnNumber % 2 == 0)
    //    {//player turn
    //         if (Units[turnNumber].GetComponent<UnitStatFunctions>().isDead() == false )
    //        {
    //            //player isn't dead
    //            //regen Mana + 5% each player turn
    //            Units[turnNumber].GetComponent<UnitStats>().mana += (Units[turnNumber].GetComponent<UnitStats>().maxMana / 100) * 5;
    //            Units[turnNumber].GetComponent<UnitStatFunctions>().mana += (Units[turnNumber].GetComponent<UnitStatFunctions>().maxMana / 100) * 5;
    //            if (Units[turnNumber].GetComponent<UnitStats>().mana > Units[turnNumber].GetComponent<UnitStats>().maxMana)
    //            {
    //                Units[turnNumber].GetComponent<UnitStats>().mana = Units[turnNumber].GetComponent<UnitStats>().maxMana;
    //            }
    //            if (Units[turnNumber].GetComponent<UnitStatFunctions>().mana > Units[turnNumber].GetComponent<UnitStatFunctions>().maxMana)
    //            {
    //                Units[turnNumber].GetComponent<UnitStatFunctions>().mana = Units[turnNumber].GetComponent<UnitStatFunctions>().maxMana;
    //            }

    //            this.playerParty.GetComponent<SelectUnit>().selectCurrentUnit(Units[turnNumber].gameObject);
    //        }
    //        else
    //        {
    //            IncreaseTurn();
    //        }
    //    }
    //    else
    //    {//enemy turn
    //        if (Units[turnNumber] != null)
    //        {//check if enemy is dead or deleted
    //            Units[turnNumber].GetComponent<EnemyUnitAction>().act();
    //            //wait until animation ends somehow
    //        }
    //        else
    //        {
    //            IncreaseTurn();
    //            nextTurn();
    //        }
    //    }
    //}

    //public void IncreaseTurn()
    //{        //if out of array loop around again
    //    if (turnNumber < 3)
    //    {
    //        turnNumber++;
    //    }
    //    else
    //    {
    //        turnNumber = 0;
    //    }

    //}
    //---------------------------
    //RPGMaker system-------------------
    //-----------------------------

    void Start()
    {
        //make a clone of player party in this scene
        this.playerParty = GameObject.Find("PlayerParty");

        StartParty();

        //create a list of ACTIVE player units
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

        //use the new list to get the player stats
        unitsStats = new List<UnitStatFunctions>();
        foreach (GameObject playerUnit in playerUnits)
        {
            UnitStatFunctions currentUnitStats = playerUnit.GetComponent<UnitStatFunctions>();
            currentUnitStats.GetComponent<UnitStatFunctions>().calculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }
        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        foreach (GameObject enemyUnit in enemyUnits)
        {
            //update enemy stats before battle starts
            enemyUnit.GetComponent<UnitStatFunctions>().updateStats();
            UnitStatFunctions currentUnitStats = enemyUnit.GetComponent<UnitStatFunctions>();
            currentUnitStats.GetComponent<UnitStatFunctions>().calculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }

        //sets active scene to the currently overlayed level
        //   SceneManager.SetActiveScene(SceneManager.GetSceneByName("Battle1"));

        unitsStats.Sort();

        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);
        this.gameOverMenu.SetActive(false);

        this.nextTurn();
    }

    public void nextTurn()
    {
        GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        if (remainingEnemyUnits.Length == 0)
        {
            this.enemyEncounter.GetComponent<CollectReward>().collectReward();
            //no enemies left
            //unload current level
            BGM.Stop();

            //Re-enable the disabled/unconscious party members
            revivePlayers();
            controlPlayers();
            GameManager1 gameManager = FindObjectOfType<GameManager1>();
            gameManager.UpdateLevelScene();

        }

        GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        if (remainingPlayerUnits.Length == 0)
        {

            // game Over
            if (gameOverMenu != null)
            {
                //TODO: play GameOver SFX
                actionsMenu.SetActive(false);
                gameOverMenu.SetActive(true);

            }

        }

        UnitStatFunctions currentUnitStats = unitsStats[0];
        unitsStats.Remove(currentUnitStats);

        //if the current unit has stats and isn't dead
        if (currentUnitStats != null && !currentUnitStats.GetComponent<UnitStatFunctions>().isDead())
        {
            GameObject currentUnit = currentUnitStats.gameObject;
            //set the current unit Here
            CurrentPlayer = currentUnit;

            currentUnitStats.GetComponent<UnitStatFunctions>().calculateNextActTurn(currentUnitStats.nextActTurn);
            unitsStats.Add(currentUnitStats);
            unitsStats.Sort();

            if (currentUnit.tag == "PlayerUnit")
            {
                //regen Mana + 5% each player turn
                currentUnit.GetComponent<UnitStatFunctions>().mana += (currentUnit.GetComponent<UnitStatFunctions>().maxMana / 100) * 5;
                if (currentUnit.GetComponent<UnitStatFunctions>().mana > currentUnit.GetComponent<UnitStatFunctions>().maxMana)
                {
                    currentUnit.GetComponent<UnitStatFunctions>().mana = currentUnit.GetComponent<UnitStatFunctions>().maxMana;
                }

                this.playerParty.GetComponent<SelectUnit>().selectCurrentUnit(currentUnit.gameObject);
            }
            else
            {
                currentUnit.GetComponent<EnemyUnitAction>().act();
            }
        }
        else
        {
            this.nextTurn();
        }
    }

    private void StartParty()
    {
        //find the party members
        GameObject Miku = GameObject.Find("PlayerParty").transform.Find("MikuUnit").gameObject;
        GameObject Luka = GameObject.Find("PlayerParty").transform.Find("LukaUnit").gameObject;
        GameObject Rin = GameObject.Find("PlayerParty").transform.Find("RinUnit").gameObject;
        GameObject Len = GameObject.Find("PlayerParty").transform.Find("LenUnit").gameObject;
        GameObject Dark = GameObject.Find("PlayerParty").transform.Find("DarkUnit").gameObject;

        //check the current scene
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            //find the unused party members and disable them

            Miku.SetActive(true);
            Luka.SetActive(true);
            Rin.SetActive(false);
            Len.SetActive(false);
            Dark.SetActive(false);

        }
        else if (scene.name == "Level2")
        {
            //find the unused party members and disable them

            Miku.SetActive(true);
            Luka.SetActive(false);
            Rin.SetActive(true);
            Len.SetActive(false);
            Dark.SetActive(false);


        }
        else if (scene.name == "Level3")
        {
            //find the unused party members and disable them
            Miku.SetActive(true);
            Luka.SetActive(false);
            Rin.SetActive(false);
            Len.SetActive(true);
            Dark.SetActive(false);

        }
        else if (scene.name == "Level4")
        {
            //find the unused party members and disable them
            Miku.SetActive(true);
            Luka.SetActive(false);
            Rin.SetActive(false);
            Len.SetActive(false);
            Dark.SetActive(true);
        }
        else if (scene.name == "Level5")
        {
            //find the unused party members and disable them
            Miku.SetActive(true);
            Luka.SetActive(false);
            Rin.SetActive(false);
            Len.SetActive(false);
            Dark.SetActive(true);
        }
    }

    public void revivePlayers()
    {
        //Revive the disabled/unconscious party members
        GameObject Miku = GameObject.Find("PlayerParty").transform.Find("MikuUnit").gameObject;
        if (Miku != null)
        {
            Miku.SetActive(true);
            Miku.GetComponent<UnitStatFunctions>().setStats();
            Miku.gameObject.tag = "PlayerUnit";
        }

        GameObject Luka = GameObject.Find("PlayerParty").transform.Find("LukaUnit").gameObject;
        if (Luka != null)
        {
            Luka.SetActive(true);
            Luka.GetComponent<UnitStatFunctions>().setStats();
            Luka.gameObject.tag = "PlayerUnit";
        }

        GameObject Rin = GameObject.Find("PlayerParty").transform.Find("RinUnit").gameObject;
        if (Rin != null)
        {
            Rin.SetActive(true);
            Rin.GetComponent<UnitStatFunctions>().setStats();
            Rin.gameObject.tag = "PlayerUnit";
        }

        GameObject Len = GameObject.Find("PlayerParty").transform.Find("LenUnit").gameObject;
        if (Len != null)
        {
            Len.SetActive(true);
            Len.GetComponent<UnitStatFunctions>().setStats();
            Len.gameObject.tag = "PlayerUnit";
        }

        GameObject Dark = GameObject.Find("PlayerParty").transform.Find("DarkUnit").gameObject;
        if (Dark != null)
        {
            Dark.SetActive(true);
            Dark.GetComponent<UnitStatFunctions>().setStats();
            Dark.gameObject.tag = "PlayerUnit";
        }
    }
    public void controlPlayers()
    {
        //find the party members
        GameObject Miku = GameObject.Find("PlayerParty").transform.Find("MikuUnit").gameObject;
        GameObject Luka = GameObject.Find("PlayerParty").transform.Find("LukaUnit").gameObject;
        GameObject Rin = GameObject.Find("PlayerParty").transform.Find("RinUnit").gameObject;
        GameObject Len = GameObject.Find("PlayerParty").transform.Find("LenUnit").gameObject;
        GameObject Dark = GameObject.Find("PlayerParty").transform.Find("DarkUnit").gameObject;

        Miku.SetActive(false);
        Luka.SetActive(false);
        Rin.SetActive(false);
        Len.SetActive(false);
        Dark.SetActive(false);
    }

    public GameObject GetCurrentPlayer()
    {
        //return Units[turnNumber];
        return CurrentPlayer;
    }
}
