using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RunFromBattle5 : MonoBehaviour {

	[SerializeField]
	private float runnningChance;

	public void tryRunning() {
		float randomNumber = Random.value;
		if (randomNumber < this.runnningChance) {
			SceneManager.LoadScene ("Level5");
		} else {
			GameObject.Find("TurnSystem").GetComponent<TurnSystem5> ().nextTurn ();
		}
	}
}
