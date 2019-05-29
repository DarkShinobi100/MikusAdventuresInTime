using UnityEngine;
using System.Collections;

public class EnemyUnitAction : MonoBehaviour {
    //this script controls the enemies battle functionality
	[SerializeField]
	private GameObject attack;

	[SerializeField]
	private string targetsTag;

	void Awake () {
		this.attack = Instantiate (this.attack);

		this.attack.GetComponent<AttackTarget> ().owner = this.gameObject;
	}

	GameObject findRandomTarget() {
        //choose a random target from the list of available player units
		GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag (targetsTag);

		if (possibleTargets.Length > 0) {
			int targetIndex = Random.Range (0, possibleTargets.Length);
			GameObject target = possibleTargets [targetIndex];

			return target; //return who we decided to attack
		}

		return null; //if there are no targets return null(0)
	}

	public void act() {
		GameObject target = findRandomTarget ();
		this.attack.GetComponent<AttackTarget> ().hit (target); //attack the person we found earlier or do nothing if it is null
	}
}
