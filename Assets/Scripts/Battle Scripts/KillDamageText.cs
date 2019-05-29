using UnityEngine;
using System.Collections;

public class KillDamageText : MonoBehaviour {
    //this script will display the damage that a unit has received from an attack above that unit
	[SerializeField]
	private float destroyTime;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, this.destroyTime);
	}
	
	void OnDestroy() {
        //next turn
        GameObject turnSystem = GameObject.Find("TurnSystem");
     //   turnSystem.GetComponent<TurnSystem1>().IncreaseTurn();
        turnSystem.GetComponent<TurnSystem1> ().nextTurn ();
	}
}
