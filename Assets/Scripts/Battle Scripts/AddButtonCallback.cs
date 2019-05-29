using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddButtonCallback : MonoBehaviour {
    //This script checks if the gameobject it is attached to has been clicked or not
	[SerializeField]
	private bool physical;
    private new AudioSource audio;

    // Use this for initialization
    void Start () {
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => addCallback());
        audio = this.gameObject.GetComponent<AudioSource>();
    }

	private void addCallback() {
		GameObject playerParty = GameObject.Find ("PlayerParty");
        //play audio
        if (audio != null)
        {
            audio.Play();
        }
        //If we have been clicked on please display the select attack menu for the player party
        playerParty.GetComponent<SelectUnit> ().selectAttack (this.physical);
	}

}
