using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TurnSystem1 : MonoBehaviour {

	private List<UnitStats> unitsStats;

	private GameObject playerParty,CurrentPlayer;

	public GameObject enemyEncounter;


	[SerializeField]
	private GameObject actionsMenu, enemyUnitsMenu, gameOverMenu;

    [SerializeField]
    private AudioSource BGM;

    void Start() {
        //make a clone of player party in this scene
        this.playerParty = GameObject.Find ("PlayerParty");

        //find the unused party members and disable them
        GameObject partyMember3 = GameObject.Find("PlayerParty").transform.Find("partyMember3").gameObject;
        partyMember3.SetActive(false);
        GameObject partyMember4 = GameObject.Find("PlayerParty").transform.Find("partyMember4").gameObject;
        partyMember4.SetActive(false);
        GameObject partyMember5 = GameObject.Find("PlayerParty").transform.Find("partyMember5").gameObject;
        partyMember5.SetActive(false);

        //create a list of ACTIVE player units
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

        //use the new list to get the player stats
        unitsStats = new List<UnitStats> ();
		foreach (GameObject playerUnit in playerUnits) {
			UnitStats currentUnitStats = playerUnit.GetComponent<UnitStatFunctions> ();
            currentUnitStats.GetComponent<UnitStatFunctions>().calculateNextActTurn(0);
			unitsStats.Add (currentUnitStats);
		}
		GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
		foreach (GameObject enemyUnit in enemyUnits) {
            //update enemy stats before battle starts
            enemyUnit.GetComponent<UnitStatFunctions>().updateStats();
			UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStatFunctions> ();
            currentUnitStats.GetComponent<UnitStatFunctions>().calculateNextActTurn(0);
            unitsStats.Add (currentUnitStats);
		}
       
        //sets active scene to the currently overlayed level
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Battle1"));

		unitsStats.Sort ();

		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (false);
        this.gameOverMenu.SetActive(false);

		this.nextTurn ();
	}

	public void nextTurn() {
		GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag ("EnemyUnit");
       if (remainingEnemyUnits.Length == 0)
        {
			this.enemyEncounter.GetComponent<CollectReward> ().collectReward ();
            //no enemies left
            //unload current level
            BGM.Stop();

            //Re-enable the disabled/unconscious party members
            GameObject Miku = GameObject.Find("PlayerParty").transform.Find("MikuUnit").gameObject;
            Miku.SetActive(true);
            Miku.GetComponent<UnitStatFunctions>().setStats();
            GameObject Luka = GameObject.Find("PlayerParty").transform.Find("LukaUnit").gameObject;
            Luka.SetActive(true);
            Luka.GetComponent<UnitStatFunctions>().setStats();
            GameObject partyMember3 =  GameObject.Find("PlayerParty").transform.Find("partyMember3").gameObject;
            partyMember3.SetActive(true);
            partyMember3.GetComponent<UnitStatFunctions>().setStats();
            GameObject partyMember4 = GameObject.Find("PlayerParty").transform.Find("partyMember4").gameObject;
            partyMember4.SetActive(true);
            partyMember4.GetComponent<UnitStatFunctions>().setStats();
            GameObject partyMember5 = GameObject.Find("PlayerParty").transform.Find("partyMember5").gameObject;
            partyMember5.SetActive(true);
            partyMember5.GetComponent<UnitStatFunctions>().setStats();

            GameManager1 gameManager = FindObjectOfType<GameManager1>();
            gameManager.UpdateScene();

        }

		GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		if (remainingPlayerUnits.Length == 0) {

            //TODO game Over
            if (gameOverMenu != null)
            {
                gameOverMenu.SetActive(true);
            }
           
		}

		UnitStats currentUnitStats = unitsStats [0];
		unitsStats.Remove (currentUnitStats);

        //if the current unit has stats and isn't dead
		if (currentUnitStats != null && !currentUnitStats.GetComponent<UnitStatFunctions>().isDead()) {
			GameObject currentUnit = currentUnitStats.gameObject;
            //set the current unit Here
            CurrentPlayer = currentUnit;

            currentUnitStats.GetComponent<UnitStatFunctions>().calculateNextActTurn (currentUnitStats.nextActTurn);
			unitsStats.Add (currentUnitStats);
			unitsStats.Sort ();

			if (currentUnit.tag == "PlayerUnit") {
				this.playerParty.GetComponent<SelectUnit> ().selectCurrentUnit (currentUnit.gameObject);
			} else {
				currentUnit.GetComponent<EnemyUnitAction> ().act ();
			}
		} else {
			this.nextTurn ();
		}
	}

    public void revivePlayers()
    {
        //Revive the disabled/unconscious party members
        GameObject Miku = GameObject.Find("PlayerParty").transform.Find("MikuUnit").gameObject;
        Miku.GetComponent<UnitStatFunctions>().setStats();
        GameObject Luka = GameObject.Find("PlayerParty").transform.Find("LukaUnit").gameObject;
        Luka.GetComponent<UnitStatFunctions>().setStats();
        GameObject partyMember3 = GameObject.Find("PlayerParty").transform.Find("partyMember3").gameObject;
        partyMember3.GetComponent<UnitStatFunctions>().setStats(); ;
        GameObject partyMember4 = GameObject.Find("PlayerParty").transform.Find("partyMember4").gameObject;
        partyMember4.GetComponent<UnitStatFunctions>().setStats();
        GameObject partyMember5 = GameObject.Find("PlayerParty").transform.Find("partyMember5").gameObject;
        partyMember5.GetComponent<UnitStatFunctions>().setStats();
    }
    public GameObject GetCurrentPlayer()
    {
        return CurrentPlayer;
    }
}
