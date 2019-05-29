using UnityEngine;
using System.Collections;

public class CollectReward : MonoBehaviour {

	[SerializeField]
	private float experience;
    //this script will reward the player with the correct amount of exp when the battle has ended
	public void Start() {
		GameObject turnSystem = GameObject.Find ("TurnSystem");
		turnSystem.GetComponent<TurnSystem1> ().enemyEncounter = this.gameObject;
	}

	public void collectReward() {
        //reward the player for winning the battle.
		GameObject[] livingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		float experiencePerUnit = this.experience / (float)livingPlayerUnits.Length;
		foreach (GameObject playerUnit in livingPlayerUnits) {
			playerUnit.GetComponent<UnitStatFunctions>().receiveExperience (experiencePerUnit);
		}

		Destroy (this.gameObject);
	}
}
