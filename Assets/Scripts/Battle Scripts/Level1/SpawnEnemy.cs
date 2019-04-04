using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	[SerializeField]
	private GameObject enemyEncounterPrefab;
    private bool playerTouch = false;
    private bool spawning = false;

	void Start() {
		DontDestroyOnLoad (this.gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Battle1" && playerTouch == true) {
			if (this.spawning) {
				Instantiate (enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (this.gameObject);
		}
        if (scene.name == "Title")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);
        }
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
            playerTouch = true;
			this.spawning = true;
            GameManager1 gameManager = FindObjectOfType<GameManager1>();
            gameManager.UpdateScene();
            SceneManager.LoadScene ("Battle1",LoadSceneMode.Additive);
		}
	}
}
