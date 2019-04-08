﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{

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
    {
        if (scene.name == "Battle1" && playerTouch == true)
        {
            if (this.spawning)
            {
                Instantiate(enemyEncounterPrefab);
            }
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);
        }
        if (scene.name == "Title")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
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
