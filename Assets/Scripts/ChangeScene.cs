using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {
    //this script will load the next level
	public void loadNextScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}
