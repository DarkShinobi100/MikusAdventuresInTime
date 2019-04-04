using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    private GameObject[] enemyUnits;

    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => addCallback());
    }

    private void addCallback()
    {
        //if the player wants to retry
        GameObject turnSystem = GameObject.Find("TurnSystem");
        if (turnSystem != null)
        {//revive the party
            turnSystem.GetComponent<TurnSystem1>().revivePlayers();
        }
        
        //delete the enemies
        enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        foreach (GameObject enemyUnit in enemyUnits)
        {
            Destroy(enemyUnit);
        }
        //if you escape delete the battle camera
        GameObject gameCamera = GameObject.Find("Main Camera");
        Destroy(gameCamera);

        //if currently in the battle scene unload it
        SceneManager.UnloadSceneAsync("Battle1");

        //load the current level
        SceneManager.LoadScene("Level1");
        GameManager1 gameManager = FindObjectOfType<GameManager1>();
        gameManager.UpdateScene();
    }

}
