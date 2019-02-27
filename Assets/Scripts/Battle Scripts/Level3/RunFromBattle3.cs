using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RunFromBattle3 : MonoBehaviour {

	[SerializeField]
	private float runnningChance;

	public void tryRunning() {
		float randomNumber = Random.value;
		if (randomNumber < this.runnningChance) {
			SceneManager.LoadScene ("Level3");
		} else {
			GameObject.Find("TurnSystem3").GetComponent<TurnSystem2> ().nextTurn ();
		}
	}
}
