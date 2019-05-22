using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    private new AudioSource audio;

    private void Start()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
    }
    //if the player wants to quit the game
    public void QuitGame()
        {
        //play audio
        if (audio != null)
        {
            audio.Play();
        }
        Application.Quit();
            Debug.Log("Game is exiting");
            //Just to make sure its working
        }
}
