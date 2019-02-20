using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddButtonCallback : MonoBehaviour {

	[SerializeField]
	private bool physical;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => addCallback());
	}

	private void addCallback() {
		GameObject playerParty = GameObject.Find ("PlayerParty");
		playerParty.GetComponent<SelectUnit> ().selectAttack (this.physical);
	}

}
