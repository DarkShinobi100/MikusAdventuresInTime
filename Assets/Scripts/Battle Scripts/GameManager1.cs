using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{

    [SerializeField]
    private GameObject player, environment;
    [SerializeField]
    private GameObject[] enemy;

    [SerializeField]
    private GameObject BGM;

    // Use this for initialization
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Title")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this);
        }
        else if (scene.name == "Level1")
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                //delete all enemies from previous level
                if (enemy[i] != null)
                {
                    Destroy(enemy[i]);
                }

            }
            //reset list to null
            enemy = null;
            //find the new enemies for this level
            enemy = GameObject.FindGameObjectsWithTag("enemy");
            player = GameObject.Find("--------------Player---------");
            environment = GameObject.Find("--------------Environment-----------------");
            BGM = GameObject.Find("BackGroundMusic");
            
        }
        else if (scene.name == "Level2")
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                //delete all enemies from previous level
                if (enemy[i] != null)
                {
                    Destroy(enemy[i]);
                }

            }
            //reset list to null
            enemy = null;
            //find the new enemies for this level
            enemy = GameObject.FindGameObjectsWithTag("enemy");
            player = GameObject.Find("--------------Player---------");
            environment = GameObject.Find("--------------Environment-----------------");
            BGM = GameObject.Find("BackGroundMusic");
        }
        else if (scene.name == "Level3")
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                //delete all enemies from previous level
                if (enemy[i] != null)
                {
                    Destroy(enemy[i]);
                }

            }
            //reset list to null
            enemy = null;
            //find the new enemies for this level
            enemy = GameObject.FindGameObjectsWithTag("enemy");

            player = GameObject.Find("--------------Player---------");
            environment = GameObject.Find("--------------Environment-----------------");
            BGM = GameObject.Find("BackGroundMusic");
        }
        else if (scene.name == "Level4")
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                //delete all enemies from previous level
                if (enemy[i] != null)
                {
                    Destroy(enemy[i]);
                }

            }
            //reset list to null
            enemy = null;
            //find the new enemies for this level
            enemy = GameObject.FindGameObjectsWithTag("enemy");

            player = GameObject.Find("--------------Player---------");
            environment = GameObject.Find("--------------Environment-----------------");
            BGM = GameObject.Find("BackGroundMusic");
        }
        else if (scene.name == "Level5")
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                //delete all enemies from previous level
                if (enemy[i] != null)
                {
                    Destroy(enemy[i]);
                }

            }
            //reset list to null
            enemy = null;
            //find the new enemies for this level
            enemy = GameObject.FindGameObjectsWithTag("enemy");

            player = GameObject.Find("--------------Player---------");
            environment = GameObject.Find("--------------Environment-----------------");
            BGM = GameObject.Find("BackGroundMusic");
        }
    }

    public void UpdateLevelScene()
    {

        if (player != null)
        {
            player.SetActive(true);
        }
        if (environment != null)
        {
            environment.SetActive(true);
        }
        if (BGM != null)
        {
            BGM.GetComponent<AudioSource>().Play();
        }
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i] != null)
            {
                enemy[i].SetActive(true);
            }

        }

        //if currently in the battle scene unload it
        SceneManager.UnloadSceneAsync("Battle1");
    }

    public void UpdateBattleScene()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i] != null)
            {
                enemy[i].SetActive(false);
            }
        }
        if (player != null)
        {
            player.SetActive(false);
        }
        if (environment != null)
        {
            environment.SetActive(false);
        }
        if (BGM != null)
        {
            BGM.GetComponent<AudioSource>().Stop();
        }
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i] != null)
            {
                enemy[i].SetActive(false);
            }

        }
    }

    public void UpdateEnemyList()
    {
        //find enemies again
        enemy = GameObject.FindGameObjectsWithTag("enemy");
    }
}
