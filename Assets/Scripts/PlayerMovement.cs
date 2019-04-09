using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
	private float speed;
    [SerializeField]
    private GameObject Up;
    [SerializeField]
    private GameObject Down;
    [SerializeField]
    private GameObject Left;
    [SerializeField]
    private GameObject Right;
    [SerializeField]
    private GameObject DeactivateButtons;

    private bool canMove;

    [SerializeField]
	private Animator animator;
    //[SerializeField]
    //private AudioSource audio;

    private float Horizontal;
    private float Vertical;

    private float newVelocityX;
    private float newVelocityY;

    private SimpleTouchArea UpButton;
    private SimpleTouchArea DownButton;
    private SimpleTouchArea LeftButton;
    private SimpleTouchArea RightButton;

    private void Start()
    {
        canMove = true;
    }
    void FixedUpdate () {

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        if (canMove)
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
       
            Vector3 currentVelocity = gameObject.GetComponent<Rigidbody>().velocity;

            newVelocityX = 0f;
            if (Horizontal < 0 && currentVelocity.x <= 0)
            {
                newVelocityX = -speed;
                animator.SetInteger("DirectionX", -1);
                Up.SetActive(false);
                Down.SetActive(false);
                Right.SetActive(false);
                //TODO play walk sound
            }
            else if (Horizontal > 0 && currentVelocity.x >= 0)
            {
                newVelocityX = speed;
                animator.SetInteger("DirectionX", 1);
                Up.SetActive(false);
                Down.SetActive(false);
                Left.SetActive(false);
                //TODO play walk sound
            }
            else
            {
                animator.SetInteger("DirectionX", 0);
            }

            newVelocityY = 0f;
            if (Vertical < 0 && currentVelocity.y <= 0)
            {
                newVelocityY = -speed;
                animator.SetInteger("DirectionY", -1);
                Up.SetActive(false);
                Left.SetActive(false);
                Right.SetActive(false);
                //TODO play walk sound
            }
            else if (Vertical > 0 && currentVelocity.y >= 0)
            {
                newVelocityY = speed;
                animator.SetInteger("DirectionY", 1);
                Down.SetActive(false);
                Left.SetActive(false);
                Right.SetActive(false);
                //TODO play walk sound
            }
            else
            {
                animator.SetInteger("DirectionY", 0);
            }

            if(newVelocityX == 0 && newVelocityY == 0)
            {
                Up.SetActive(true);
                Down.SetActive(true);
                Left.SetActive(true);
                Right.SetActive(true);

                //TODO stop walk sound
            }

            if (canMove) //if you can move update the player
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(newVelocityX, 0, newVelocityY);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
        }
        else
        {
            Horizontal = 0;
            Vertical = 0;
            DeactivateAllButtons();
        }
#else
        if (canMove)
        {
            Horizontal = 0;
            Vertical = 0;

             UpButton = Up.GetComponentInChildren<SimpleTouchArea>();
             DownButton = Down.GetComponentInChildren<SimpleTouchArea>();
             LeftButton = Left.GetComponentInChildren<SimpleTouchArea>();
             RightButton = Right.GetComponentInChildren<SimpleTouchArea>();        

             Vector3 currentVelocity = gameObject.GetComponent<Rigidbody> ().velocity;

		    newVelocityX = 0f;
		    if (LeftButton.Pressed() && currentVelocity.x <= 0) 
            {
		        newVelocityX = -speed;
		        animator.SetInteger ("DirectionX", -1);
                Up.SetActive(false);
                Down.SetActive(false);
                Right.SetActive(false);
		    } 
            else if (RightButton.Pressed()  && currentVelocity.x >= 0) 
            {
		        newVelocityX = speed;
		        animator.SetInteger ("DirectionX", 1);
                Up.SetActive(false);
                Down.SetActive(false);
                Left.SetActive(false);
		    } 
            else
            {
			    animator.SetInteger ("DirectionX", 0);
		    }

		    newVelocityY = 0f;
		    if (DownButton.Pressed()  && currentVelocity.y <= 0)
            {
		        newVelocityY = -speed;
		        animator.SetInteger ("DirectionY", -1);
                Up.SetActive(false);
                Left.SetActive(false);
                Right.SetActive(false);
		    } 
            else if (UpButton.Pressed() && currentVelocity.y >= 0)
            {
		        newVelocityY = speed;
		        animator.SetInteger ("DirectionY", 1);
                Down.SetActive(false);
                Left.SetActive(false);
                Right.SetActive(false);
		    } 
            else
            {
			    animator.SetInteger ("DirectionY", 0);
		    }

        
            if(newVelocityX == 0 && newVelocityY == 0)
            {
                Up.SetActive(true);
                Down.SetActive(true);
                Left.SetActive(true);
                Right.SetActive(true);
            }
        
		    gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (newVelocityX,0, newVelocityY);
        
        }
        else
        {
            Horizontal = 0;
            Vertical = 0;
            DeactivateAllButtons();
        }

#endif

    }
    private void OnEnable()
    {
        //stop movement
        newVelocityX = 0f;
        newVelocityY = 0f;

        //turn on the buttons
        Up.SetActive(true);
        Down.SetActive(true);
        Left.SetActive(true);
        Right.SetActive(true);
    }

    public void DeactivateAllButtons()
    {
        //stop movement
        newVelocityX = 0f;
        newVelocityY = 0f;

        //turn off the buttons
        Up.SetActive(false);
        Down.SetActive(false);
        Left.SetActive(false);
        Right.SetActive(false);
        DeactivateButtons.SetActive(false);
    }

    public void ReactivateAllButtons()
    {
        //turn off the buttons
        Up.SetActive(true);
        Down.SetActive(true);
        Left.SetActive(true);
        Right.SetActive(true);
        DeactivateButtons.SetActive(true);
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
