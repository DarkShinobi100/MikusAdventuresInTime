using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartyManager : MonoBehaviour {

    [SerializeField]
    private GameObject player1, player2, player3, player4, player5;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Battle1")
        {
            player1.SetActive(true);
            player2.SetActive(true);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
        }
        else if (scene.name == "Battle2")
        {
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(true);
            player4.SetActive(false);
            player5.SetActive(false);
        }
        else if (scene.name == "Battle3")
        {
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(true);
            player5.SetActive(false);
        }
        else if (scene.name == "Battle4")
        {
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(true);
            player5.SetActive(false);
        }
        else if (scene.name == "Battle5")
        {
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
