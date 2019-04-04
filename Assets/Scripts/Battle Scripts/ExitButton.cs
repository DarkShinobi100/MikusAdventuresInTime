using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
        //if the player wants to quit the game
       public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Game is exiting");
            //Just to make sure its working
        }
}
