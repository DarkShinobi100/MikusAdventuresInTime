using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartBattle : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;

        this.gameObject.SetActive(false);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Title")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);
        }
        else if (scene.name == "Battle1")
        {
            this.gameObject.SetActive(true);
        }
        else if (scene.name == "Battle2")
        {
            this.gameObject.SetActive(true);
        }
        else if (scene.name == "Battle3")
        {
            this.gameObject.SetActive(true);
        }
        else if (scene.name == "Battle4")
        {
            this.gameObject.SetActive(true);
        }
        else if (scene.name == "Battle5")
        {
            this.gameObject.SetActive(true);
        }
    }

}
