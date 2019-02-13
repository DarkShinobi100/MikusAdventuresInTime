using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
	private float speed;
    public SimpleTouchArea Up;
    public SimpleTouchArea Down;
    public SimpleTouchArea Left;
    public SimpleTouchArea Right;
    public GameObject canvas;

    [SerializeField]
	private Animator animator;

	void FixedUpdate () {

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

        canvas.SetActive(false);

        float Horizontal = Input.GetAxis ("Horizontal");
		float Vertical = Input.GetAxis ("Vertical");
        Vector3 currentVelocity = gameObject.GetComponent<Rigidbody>().velocity;

        float newVelocityX = 0f;
        if (Horizontal < 0 && currentVelocity.x <= 0)
        {
            newVelocityX = -speed;
            animator.SetInteger("DirectionX", -1);
        }
        else if (Horizontal > 0 && currentVelocity.x >= 0)
        {
            newVelocityX = speed;
            animator.SetInteger("DirectionX", 1);
        }
        else
        {
            animator.SetInteger("DirectionX", 0);
        }

        float newVelocityY = 0f;
        if (Vertical < 0 && currentVelocity.y <= 0)
        {
            newVelocityY = -speed;
            animator.SetInteger("DirectionY", -1);
        }
        else if (Vertical > 0 && currentVelocity.y >= 0)
        {
            newVelocityY = speed;
            animator.SetInteger("DirectionY", 1);
        }
        else
        {
            animator.SetInteger("DirectionY", 0);
        }

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(newVelocityX,0, newVelocityY);
#else
        float Horizontal = 0;
        float Vertical = 0;

        

         Vector3 currentVelocity = gameObject.GetComponent<Rigidbody> ().velocity;

		float newVelocityX = 0f;
		if (Left.Pressed() && currentVelocity.x <= 0) {
			newVelocityX = -speed;
			animator.SetInteger ("DirectionX", -1);
		} else if (Right.Pressed()  && currentVelocity.x >= 0) {
			newVelocityX = speed;
			animator.SetInteger ("DirectionX", 1);
		} else {
			animator.SetInteger ("DirectionX", 0);
		}

		float newVelocityY = 0f;
		if (Down.Pressed()  && currentVelocity.y <= 0) {
			newVelocityY = -speed;
			animator.SetInteger ("DirectionY", -1);
		} else if (Up.Pressed() && currentVelocity.y >= 0) {
			newVelocityY = speed;
			animator.SetInteger ("DirectionY", 1);
		} else {
			animator.SetInteger ("DirectionY", 0);
		}

		gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (newVelocityX,0, newVelocityY);

#endif

    }
}
