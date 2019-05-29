using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolArea : MonoBehaviour {
    //this script will tell the AI that the player is nearby or not
    [SerializeField]
    private GameObject enemy;
    private bool playerNearby = false;
    [SerializeField]
    private SphereCollider enemyArea;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNearby = true;
            //tell the enemy the player is nearby
            enemy.GetComponent<EnemyTrackMovement>().SetPlayerNeaby(playerNearby);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNearby = false;
            //tell the enemy the player is no longer nearby
            enemy.GetComponent<EnemyTrackMovement>().SetPlayerNeaby(playerNearby);
        }
    }
}
