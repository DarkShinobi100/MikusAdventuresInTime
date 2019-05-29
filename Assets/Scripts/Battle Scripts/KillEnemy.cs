using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {
    //this script will delete an enemy when they are dead
	public GameObject menuItem;

	void OnDestroy() {
		Destroy (this.menuItem);
	}
}
