using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RunFromBattle : MonoBehaviour {

	[SerializeField]
	private float runnningChance;
    private bool boss;
    private GameObject[] enemyUnits;

    private void Start()
    {
        boss = false; //set false as default
       enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        foreach (GameObject enemyUnit in enemyUnits)
        { //check if boss is present
            if (enemyUnit.name.Contains("BOSS"))
            {//BOSS found!
                boss = true;
                Debug.Log("BOSS Found");
            }
        }
    }
    public void tryRunning() {
		float randomNumber = Random.value;

        //if there is a boss you cannot escape
        if (boss== false && randomNumber < this.runnningChance) {

            GameManager1 gameManager = FindObjectOfType<GameManager1>();
            gameManager.UpdateScene();

            //delete the enemies
            enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
            foreach (GameObject enemyUnit in enemyUnits)
            {
                Destroy(enemyUnit);
            }

            //if you escape delete the battle camera
            GameObject gameCamera = GameObject.Find("Main Camera");
            Destroy(gameCamera);

            GameObject turnSystem =  GameObject.Find("TurnSystem");
            if (turnSystem != null)
            {
                turnSystem.GetComponent<TurnSystem1>().revivePlayers();
            }

        } else {
            GameObject.Find("PlayerParty").GetComponent<SelectUnit>().setMenus();
            GameObject.Find("TurnSystem").GetComponent<TurnSystem1> ().nextTurn ();
		}

    }
}
