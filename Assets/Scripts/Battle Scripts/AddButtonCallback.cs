using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddButtonCallback : MonoBehaviour {

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
        playerParty.GetComponent<SelectUnit> ().selectAttack (this.physical);
	}

}
