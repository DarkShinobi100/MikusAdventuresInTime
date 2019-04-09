using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    [SerializeField]
    private Text dialogueText;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private GameObject dialogueBox;
    [SerializeField]
    private GameObject nameBox;
    [SerializeField]
    private string[] dialogueLines;
    [SerializeField]
    private int currentLine;

    //confirm button
    [SerializeField]
    private GameObject confirm;
    private SimpleTouchArea ConfirmButton;

    // Use this for initialization
    void Start () {
        ConfirmButton = confirm.GetComponentInChildren<SimpleTouchArea>();
        dialogueText.text = dialogueLines[currentLine];
	}
	
	// Update is called once per frame
	void Update () {
        //is the dialogue box open in the scene?
		if(dialogueBox.activeInHierarchy)
        {//yes it is
            confirm.SetActive(true);
            if(ConfirmButton.Pressed() || Input.GetButtonUp("Fire1"))
            {
                currentLine++;

                if (currentLine >= dialogueLines.Length)
                {
                    //end of the array
                    dialogueBox.SetActive(false);
                    confirm.SetActive(false);
                }
                else
                {
                    dialogueText.text = dialogueLines[currentLine];
                }
            }


        }


	}
}
