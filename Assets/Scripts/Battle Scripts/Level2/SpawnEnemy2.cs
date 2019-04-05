using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnEnemy2 : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyEncounterPrefab;
    private bool playerTouch = false;
    private bool spawning = false;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Battle2" && playerTouch == true)
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
            GameManager2 gameManager = FindObjectOfType<GameManager2>();
            gameManager.UpdateScene();
            SceneManager.LoadScene("Battle2", LoadSceneMode.Additive);
        }
    }
}
