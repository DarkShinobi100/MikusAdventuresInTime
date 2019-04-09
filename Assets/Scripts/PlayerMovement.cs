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
	private Animator animator;
    //[SerializeField]
    //private AudioSource audio;

    private float newVelocityX;
    private float newVelocityY;

    private SimpleTouchArea UpButton;
    private SimpleTouchArea DownButton;
    private SimpleTouchArea LeftButton;
    private SimpleTouchArea RightButton;

    void FixedUpdate () {

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER


        float Horizontal = Input.GetAxis ("Horizontal");
		float Vertical = Input.GetAxis ("Vertical");
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

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(newVelocityX,0, newVelocityY);
#else
        float Horizontal = 0;
        float Vertical = 0;

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
		} else if (RightButton.Pressed()  && currentVelocity.x >= 0) 
        {
		    newVelocityX = speed;
		    animator.SetInteger ("DirectionX", 1);
            Up.SetActive(false);
            Down.SetActive(false);
            Left.SetActive(false);
		} else
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

}
