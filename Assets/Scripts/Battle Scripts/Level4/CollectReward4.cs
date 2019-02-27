using UnityEngine;
using System.Collections;

public class CollectReward4 : MonoBehaviour {

	[SerializeField]
	private float experience;

	public void Start() {
		GameObject turnSystem = GameObject.Find ("TurnSystem");
		turnSystem.GetComponent<TurnSystem4> ().enemyEncounter = this.gameObject;
	}

	public void collectReward() {
		GameObject[] livingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		float experiencePerUnit = this.experience / (float)livingPlayerUnits.Length;
		foreach (GameObject playerUnit in livingPlayerUnits) {
			playerUnit.GetComponent<UnitStats> ().receiveExperience (experiencePerUnit);
		}

		Destroy (this.gameObject);
	}
}
