using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    [SerializeField]
    private Text dialogueText;
    [SerializeField]
    private Text nameText;
    
    //has to be public for activator to check if it is active in the scene
    public GameObject dialogueBox;

    private GameObject TargetNPC;

    [SerializeField]
    private GameObject nameBox;
    [SerializeField]
    private string[] dialogueLines;
    [SerializeField]
    private int currentLine;
    private bool justStarted;
    private bool BossWarning;

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
                        if (BossWarning)
                        {
                            //end of the array
                            dialogueBox.SetActive(false);
                            player.GetComponent<PlayerMovement>().SetCanMove(true); //let the player move
                            player.GetComponent<PlayerMovement>().ReactivateAllButtons();

                            //remove the person warning you about the boss
                            Destroy(TargetNPC);
                        }
                        else
                        {
                            //end of the array
                            dialogueBox.SetActive(false);
                            player.GetComponent<PlayerMovement>().SetCanMove(true); //let the player move
                            player.GetComponent<PlayerMovement>().ReactivateAllButtons();
                        }
                    }
                    else
                    {
                        CheckIfName(); //is this line a character name?
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

    public void ShowDialogue(string[] newLines, bool isPerson)
    {
        //overwrite current array of dialogue with the new values
        dialogueLines = newLines;

        currentLine = 0;
        CheckIfName(); 

        dialogueText.text = dialogueLines[currentLine];
        dialogueBox.SetActive(true);
        justStarted = true;

        nameBox.gameObject.SetActive(isPerson);

        player.GetComponent<PlayerMovement>().SetCanMove(false); //stop the player moving
        player.GetComponent<PlayerMovement>().DeactivateAllButtons();
    }

    public void SetBossWarning(bool value)
    {
        //overwrite current value for BossWarning
        BossWarning = value;
    }

    public void SetTargetNPC(GameObject Speaker)
    {
        //overwrite current value for BossWarning
        TargetNPC = Speaker;
    }

    public void CheckIfName()
    {
        if(dialogueLines[currentLine].StartsWith("n-")) //does this line contain a character name?
        {
            nameText.text = dialogueLines[currentLine].Replace("n-",""); //yeah, so set it in the box
            currentLine++; //skip this line in the main box
        }
    }
}
