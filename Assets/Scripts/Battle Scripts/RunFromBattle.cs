using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RunFromBattle : MonoBehaviour
{

    [SerializeField]
    private float runnningChance;
    private bool boss;
    private GameObject[] enemyUnits;
    private GameManager1 gameManager;

    private void Start()
    {
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
        float randomNumber = Random.value;

        //if there is a boss you cannot escape
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
            turnSystem.GetComponent<TurnSystem1>().IncreaseTurn();
            turnSystem.GetComponent<TurnSystem1>().nextTurn();

            GameObject.Find("PlayerParty").GetComponent<SelectUnit>().setMenus();

        }

    }
}
