using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject player, environment;

    [SerializeField]
    private AudioSource BGM;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

     public void UpdateScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Battle1")
        {
            player.SetActive(true);
            environment.SetActive(true);
            BGM.Play();
            SceneManager.UnloadSceneAsync("Battle1");
        }
        else if (scene.name == "Level1")
        { 
            player.SetActive(false);
            environment.SetActive(false);
            BGM.Stop();
        }
    }

}
