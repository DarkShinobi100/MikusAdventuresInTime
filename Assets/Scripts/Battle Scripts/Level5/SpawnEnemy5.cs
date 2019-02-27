using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnEnemy5 : MonoBehaviour {

	[SerializeField]
	private GameObject enemyEncounterPrefab;

	private bool spawning = false;

	void Start() {
		DontDestroyOnLoad (this.gameObject);

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Battle5") {
			if (this.spawning) {
				Instantiate (enemyEncounterPrefab);
			}
			SceneManager.sceneLoaded -= OnSceneLoaded;
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			this.spawning = true;
			SceneManager.LoadScene ("Battle5");
		}
	}
}
