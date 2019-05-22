using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    private GameObject[] enemyUnits;
    private new AudioSource audio;
    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => addCallback());
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    private void addCallback()
    {
        //play audio
        if (audio != null)
        {
            audio.Play();
        }

        //if the player wants to retry       
        //if currently in the battle scene unload it
        SceneManager.LoadScene("Title", LoadSceneMode.Single );
    }

}
