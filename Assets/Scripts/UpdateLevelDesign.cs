using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateLevelDesign : MonoBehaviour
{

    [SerializeField]
    private GameObject[] images;
    [SerializeField]
    private GameObject[] BGM;

    private void Start()
    {
        //check the current scene
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            //set the image base on the scene
            images[0].SetActive(true);
            images[1].SetActive(false);
            images[2].SetActive(false);
            images[3].SetActive(false);
            images[4].SetActive(false);

            //set the image base on the scene
            BGM[0].SetActive(true);
            BGM[1].SetActive(false);
            BGM[2].SetActive(false);
            BGM[3].SetActive(false);
            BGM[4].SetActive(false);
        }
        else if (scene.name == "Level2")
        {
            //set the image base on the scene
            images[0].SetActive(false);
            images[1].SetActive(true);
            images[2].SetActive(false);
            images[3].SetActive(false);
            images[4].SetActive(false);

            //set the image base on the scene
            BGM[0].SetActive(false);
            BGM[1].SetActive(true);
            BGM[2].SetActive(false);
            BGM[3].SetActive(false);
            BGM[4].SetActive(false);
        }
        else if (scene.name == "Level3")
        {
            //set the image base on the scene
            images[0].SetActive(false);
            images[1].SetActive(false);
            images[2].SetActive(true);
            images[3].SetActive(false);
            images[4].SetActive(false);

            //set the image base on the scene
            BGM[0].SetActive(false);
            BGM[1].SetActive(false);
            BGM[2].SetActive(true);
            BGM[3].SetActive(false);
            BGM[4].SetActive(false);
        }
        else if (scene.name == "Level4")
        {
            //set the image base on the scene
            images[0].SetActive(false);
            images[1].SetActive(false);
            images[2].SetActive(false);
            images[3].SetActive(true);
            images[4].SetActive(false);

            //set the image base on the scene
            BGM[0].SetActive(false);
            BGM[1].SetActive(false);
            BGM[2].SetActive(false);
            BGM[3].SetActive(true);
            BGM[4].SetActive(false);
        }
        else if (scene.name == "Level5")
        {
            //set the image base on the scene
            images[0].SetActive(false);
            images[1].SetActive(false);
            images[2].SetActive(false);
            images[3].SetActive(false);
            images[4].SetActive(true);

            //set the image base on the scene
            BGM[0].SetActive(false);
            BGM[1].SetActive(false);
            BGM[2].SetActive(false);
            BGM[3].SetActive(false);
            BGM[4].SetActive(true);
        }
    }
}
