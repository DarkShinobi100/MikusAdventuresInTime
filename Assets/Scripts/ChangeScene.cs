using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void loadNextScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}
