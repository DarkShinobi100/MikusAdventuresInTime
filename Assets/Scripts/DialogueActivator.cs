using UnityEngine;

public class DialogueActivator : MonoBehaviour {

    [SerializeField]
    private string[] lines;

    private bool playerNearby;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private SimpleTouchArea confirmButton;

    [SerializeField]
    private bool BossWarning = false;
    [SerializeField]
    private bool isPerson = true;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(playerNearby && confirmButton.Pressed() && !DialogueManager.instance.dialogueBox.activeInHierarchy) //is the player nearby? and the button is pressed and we haven't already turned on the dialogue box
         {
            //send this persons lines to the dialogue manager
            player.GetComponent<PlayerMovement>().DeactivateAllButtons();
            player.GetComponent<PlayerMovement>().SetCanMove(false); //stop the player moving
            DialogueManager.instance.ShowDialogue(lines,isPerson);
            DialogueManager.instance.SetBossWarning(BossWarning);
            DialogueManager.instance.SetTargetNPC(this.gameObject);
        }

        if (playerNearby && BossWarning && !DialogueManager.instance.dialogueBox.activeInHierarchy) //is the player nearby? and this is a boss warning
        {
            player.GetComponent<PlayerMovement>().DeactivateAllButtons();
            player.GetComponent<PlayerMovement>().SetCanMove(false); //stop the player moving

            //send this persons lines to the dialogue manager
            DialogueManager.instance.ShowDialogue(lines, isPerson);
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
