using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RunFromBattle2 : MonoBehaviour {

	[SerializeField]
	private float runnningChance;

	public void tryRunning() {
		float randomNumber = Random.value;
		if (randomNumber < this.runnningChance) {
			SceneManager.LoadScene ("Level2");
		} else {
			GameObject.Find("TurnSystem").GetComponent<TurnSystem2> ().nextTurn ();
		}
	}
}
