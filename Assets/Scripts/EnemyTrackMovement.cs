using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrackMovement : MonoBehaviour {
    //this script controls the AI that will follow the player
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject player;
    private Vector3 orignalPosition;
    private bool playerNearby = false;

    [SerializeField]
    private Animator animator;

    void Start()
    {
        enemy = this.gameObject;
        orignalPosition = this.gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        if (playerNearby)
        {
            float distanceX = enemy.transform.position.x - player.transform.position.x; 
            if (distanceX < 0.01f)
            {
                //walk right
                animator.SetInteger("DirectionX", 1);
            }
            else
            {
                //walk left
                animator.SetInteger("DirectionX", -1);
            }

            //code for following the player
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, Time.deltaTime * moveSpeed);
            if (Vector3.Distance(transform.position, player.transform.position) < .001f)
            {
                Debug.Log("Fight me!");
            }
        }
        else
        {
            //if player not nearby, go home
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, orignalPosition, Time.deltaTime * moveSpeed);

            float distanceX = enemy.transform.position.x - orignalPosition.x;
            if (distanceX < 0.01f)
            {
                //walk right
                animator.SetInteger("DirectionX", -1);
            }
            else
            {
                //walk left
                animator.SetInteger("DirectionX", 1);
            }

            if (Vector3.Distance(transform.position, player.transform.position) < .001f)
            {
                Debug.Log("stand guard");
                animator.SetInteger("DirectionX", 0);
            }
            animator.SetInteger("DirectionX", 0);
        }
    }

    public void SetPlayerNeaby(bool value)
    {
        playerNearby = value;
    }
}
