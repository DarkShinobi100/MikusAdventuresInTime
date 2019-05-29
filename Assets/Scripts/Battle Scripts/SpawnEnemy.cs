using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    //this script will control spawning the enemies in the encounter into the battle scene0
    [SerializeField]
    private GameObject enemyEncounterPrefab;
    private bool playerTouch = false;
    private bool spawning = false;

    [SerializeField]

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {//check which scene is being loaded
        if (scene.name == "Battle1" && playerTouch == true)
        {
            if (this.spawning)
            {//if we are spawning enemies spawn the correct ones
                Instantiate(enemyEncounterPrefab);
            }
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);
        }
        if (scene.name == "Title")
        {//if we are loading the title delete this object
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {//if we touch the player it's time to fight
        if (other.gameObject.tag == "Player")
        {
            playerTouch = true;
            this.spawning = true;
            //set tag to "BattleTarget" to prevent adding it to the active enemy list again
            this.gameObject.tag = "BattleTarget";
            GameManager1 gameManager = FindObjectOfType<GameManager1>();
            gameManager.UpdateEnemyList();
            gameManager.UpdateBattleScene();
            SceneManager.LoadScene("Battle1", LoadSceneMode.Additive);
        }
    }
}
