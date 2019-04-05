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
            enemy = null;
            player = GameObject.Find("--------------Player---------");
            environment = GameObject.Find("--------------Environment-----------------");
            BGM = GameObject.Find("BackGroundMusic");
            enemy = GameObject.FindGameObjectsWithTag("enemy");
        }
        else if (scene.name == "Level2")
        {
            enemy = null;
            player = GameObject.Find("--------------Player---------");
            environment = GameObject.Find("--------------Environment-----------------");
            BGM = GameObject.Find("BackGroundMusic");
            enemy = GameObject.FindGameObjectsWithTag("enemy");
        }
        else if (scene.name == "Level3")
        {
            enemy = null;
            player = GameObject.Find("--------------Player---------");
            environment = GameObject.Find("--------------Environment-----------------");
            BGM = GameObject.Find("BackGroundMusic");
            enemy = GameObject.FindGameObjectsWithTag("enemy");
        }
        else if (scene.name == "Level4")
        {
            enemy = null;
            player = GameObject.Find("--------------Player---------");
            environment = GameObject.Find("--------------Environment-----------------");
            BGM = GameObject.Find("BackGroundMusic");
            enemy = GameObject.FindGameObjectsWithTag("enemy");
        }
        else if (scene.name == "Level5")
        {
            enemy = null;
            player = GameObject.Find("--------------Player---------");
            environment = GameObject.Find("--------------Environment-----------------");
            BGM = GameObject.Find("BackGroundMusic");
            enemy = GameObject.FindGameObjectsWithTag("enemy");
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
}
