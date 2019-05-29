using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour {
    [SerializeField]
    private int level;
    //this script will load the level set in the inspector
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level"+ level, LoadSceneMode.Single);
        }
    }
}
