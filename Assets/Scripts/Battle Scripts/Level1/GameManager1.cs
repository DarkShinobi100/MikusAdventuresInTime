using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager1 : MonoBehaviour {

    [SerializeField]
    private GameObject player, environment,enemy1,enemy2,enemy3;

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
            if(enemy1 !=null)
            {
                enemy1.SetActive(true);
            }
            if(enemy2 != null)
            {
                enemy2.SetActive(true);
            }
            if(enemy3 !=null)
            {
                enemy3.SetActive(true);
            }

            SceneManager.UnloadSceneAsync("Battle1");
        }
        else if (scene.name == "Level1")
        {
            if (enemy1 != null)
            {
                enemy1.SetActive(false);
            }
            if (enemy2 != null)
            {
                enemy2.SetActive(false);
            }
            if (enemy3 != null)
            {
                enemy3.SetActive(false);
            }

            player.SetActive(false);
            environment.SetActive(false);
            BGM.Stop();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
}
