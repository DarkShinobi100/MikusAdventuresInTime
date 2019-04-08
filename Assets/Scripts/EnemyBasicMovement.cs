using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement : MonoBehaviour
{

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject[] targets;
    //^^ array of target destinations
    private Vector3 destination;
    private Vector3 oldLocation;

    [SerializeField]
    private Animator animator;

    void Start()
    {
        enemy = this.gameObject;
        destination = targets[0].transform.position; //set initial destination to the start point
    }


    void Update()
    {
       if (enemy.transform.position != destination) //we are not at the destination
        {
            //move closer to it
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, destination, Time.deltaTime * moveSpeed);
            
            //control animations
            if (destination == targets[1].transform.position)
            {
                //were moving right
                animator.SetInteger("DirectionX", 0);
                animator.SetInteger("DirectionY", -1);              
            }
            else if (destination == targets[2].transform.position)
            {
                //we're moving down
                animator.SetInteger("DirectionX", -1);
                animator.SetInteger("DirectionY", 0);

            }
            else if (destination == targets[3].transform.position)
            {
                //were moving left
                animator.SetInteger("DirectionX", 0);
                animator.SetInteger("DirectionY", 1);

            }
            else
            {
                //we're moving up
                animator.SetInteger("DirectionX", 1);
                animator.SetInteger("DirectionY", 0);
            }

        }
        else if (destination == targets[0].transform.position)
        { //change destination from target 1 to 2
            destination = targets[1].transform.position;
        }
        else if (destination == targets[1].transform.position)
        { //change destination from target 2 to 3
            destination = targets[2].transform.position;
        }
        else if (destination == targets[2].transform.position)
        { //change destination from target 3 to 4
            destination = targets[3].transform.position;
        }
        else if (destination == targets[3].transform.position)
        { //change destination from target 4 to 0
            destination = targets[0].transform.position;
        }

    }
}
