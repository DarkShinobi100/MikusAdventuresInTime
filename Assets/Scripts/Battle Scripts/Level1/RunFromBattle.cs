using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RunFromBattle : MonoBehaviour {

	[SerializeField]
	private float runnningChance;

	public void tryRunning() {
		float randomNumber = Random.value;
		if (randomNumber < this.runnningChance) {
			SceneManager.LoadScene ("Level1");
		} else {
			GameObject.Find("TurnSystem").GetComponent<TurnSystem1> ().nextTurn ();
		}
	}
}
