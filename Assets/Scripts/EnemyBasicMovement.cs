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

    [SerializeField]
    private Animator animator;

    void Start()
    {
        enemy = this.gameObject;
        destination = targets[0].transform.position; //set initial destination to the start point
    }


    void Update()
    {
        //move code
        //        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, destination, Time.deltaTime * moveSpeed);

        if (enemy.transform.position != destination) //we are not at the destination
        {
            //move closer to it
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, destination, Time.deltaTime * moveSpeed);
        }
        else if (destination == targets[0].transform.position)
        { //change destination
            destination = targets[1].transform.position;
        }
        else if (destination == targets[1].transform.position)
        { //change destination
            destination = targets[2].transform.position;
        }
        else if (destination == targets[2].transform.position)
        { //change destination
            destination = targets[3].transform.position;
        }
        else if (destination == targets[3].transform.position)
        { //change destination
            destination = targets[0].transform.position;
        }

    }
}
