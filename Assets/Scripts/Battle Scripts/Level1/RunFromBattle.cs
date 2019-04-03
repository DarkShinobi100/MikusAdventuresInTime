using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RunFromBattle : MonoBehaviour {

	[SerializeField]
	private float runnningChance;

	public void tryRunning() {
		float randomNumber = Random.value;

        GameObject[] BossUnits = GameObject.FindGameObjectsWithTag("EnemyBOSS");

        if (BossUnits.Length == 0 && randomNumber < this.runnningChance) {

            GameManager1 gameManager = FindObjectOfType<GameManager1>();
            gameManager.UpdateScene();

            //delete the enemies
            GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
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
			GameObject.Find("TurnSystem").GetComponent<TurnSystem1> ().nextTurn ();
		}

    }
}
