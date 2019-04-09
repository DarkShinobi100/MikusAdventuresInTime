using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    [SerializeField]
    private Text dialogueText;
    [SerializeField]
    private Text nameText;
    
    public GameObject dialogueBox;

    [SerializeField]
    private GameObject nameBox;
    [SerializeField]
    private string[] dialogueLines;
    [SerializeField]
    private int currentLine;
    private bool justStarted;

    //confirm button
    [SerializeField]
    private GameObject confirm;
    private SimpleTouchArea ConfirmButton;

    public static DialogueManager instance;

    [SerializeField]
    private GameObject player;

    // Use this for initialization
    void Start () {
        instance = this;
        ConfirmButton = confirm.GetComponentInChildren<SimpleTouchArea>();
       // dialogueText.text = dialogueLines[currentLine];
	}
	
	// Update is called once per frame
	void Update () {
        //is the dialogue box open in the scene?
		if(dialogueBox.activeInHierarchy)
        {//yes it is
            confirm.SetActive(true);
            if(ConfirmButton.Pressed() || Input.GetButtonUp("Fire1"))
            {
                if (justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogueLines.Length)
                    {
                        //end of the array
                        dialogueBox.SetActive(false);


                        player.GetComponent<PlayerMovement>().SetCanMove(true); //let the player move
                        player.GetComponent<PlayerMovement>().ReactivateAllButtons();

                    }
                    else
                    {
                        dialogueText.text = dialogueLines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
            }


        }
	}

    public void ShowDialogue(string[] newLines)
    {
        //overwrite current array of dialogue with the new values
        dialogueLines = newLines;

        currentLine = 0;

        dialogueText.text = dialogueLines[0];
        dialogueBox.SetActive(true);
        justStarted = true;

        player.GetComponent<PlayerMovement>().SetCanMove(false); //stop the player moving
        player.GetComponent<PlayerMovement>().DeactivateAllButtons();
    }
}
