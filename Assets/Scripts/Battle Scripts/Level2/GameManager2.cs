using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{

    [SerializeField]
    private GameObject player, environment;
    [SerializeField]
    private GameObject[] enemy;

    [SerializeField]
    private AudioSource BGM;

    // Use this for initialization
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level2")
        {
            player = GameObject.Find("--------------Player---------");
            environment = GameObject.Find("--------------Environment-----------------");
            BGM = GameObject.Find("BackGroundMusic").GetComponent<AudioSource>();
            enemy = GameObject.FindGameObjectsWithTag("enemy");
        }
    }

    public void UpdateScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Battle2")
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
                BGM.Play();
            }
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i] != null)
                {
                    enemy[i].SetActive(true);
                }

            }

            //if currently in the battle scene unload it
            SceneManager.UnloadSceneAsync("Battle2");
        }
        else if (scene.name == "Level2")
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
                BGM.Stop();
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
