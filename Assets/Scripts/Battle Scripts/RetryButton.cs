using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    private GameObject[] enemyUnits;

    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => addCallback());
    }

    private void addCallback()
    {
        //if the player wants to retry
       
        //if currently in the battle scene unload it
        SceneManager.LoadScene("Title", LoadSceneMode.Single );
    }

}
