using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour {
   
    private bool playerTouch = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerTouch = true;
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
    }
}
