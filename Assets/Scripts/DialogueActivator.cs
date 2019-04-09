using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour {

    [SerializeField]
    private string[] lines;

    private bool playerNearby;

    //confirm button
    [SerializeField]
    private GameObject confirm;
    private SimpleTouchArea ConfirmButton;

    [SerializeField]
    private bool BossWarning = false;
    [SerializeField]
    private bool isPerson = true;

    // Use this for initialization
    void Start () {
        ConfirmButton = confirm.GetComponentInChildren<SimpleTouchArea>();
    }
	
	// Update is called once per frame
	void Update () {
		if((playerNearby && ConfirmButton.Pressed() && !DialogueManager.instance.dialogueBox.activeInHierarchy) || //is the player nearby? and the button is pressed and we haven't already turned on the dialogue box
            (playerNearby && Input.GetButtonDown("Fire1") && !DialogueManager.instance.dialogueBox.activeInHierarchy))
        {
            //send this persons lines to the dialogue manager
            DialogueManager.instance.ShowDialogue(lines,isPerson);
            DialogueManager.instance.SetBossWarning(BossWarning);
            DialogueManager.instance.SetTargetNPC(this.gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNearby = false;
        }
    }
}
