using UnityEngine;
using System.Collections;

public class KillDamageText5 : MonoBehaviour {

	[SerializeField]
	private float destroyTime;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, this.destroyTime);
	}
	
	void OnDestroy() {
		GameObject turnSystem = GameObject.Find ("TurnSystem");
		turnSystem.GetComponent<TurnSystem5> ().nextTurn ();
	}
}
