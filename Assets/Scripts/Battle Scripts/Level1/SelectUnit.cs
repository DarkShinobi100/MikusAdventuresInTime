using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectUnit : MonoBehaviour {

	private GameObject currentUnit;

	private GameObject actionsMenu, enemyUnitsMenu;

	void Awake() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Battle1") {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyUnit"); //find any enemies in the scene
            GameObject[] Bosses = GameObject.FindGameObjectsWithTag("EnemyBOSS"); // find any BOSSES in the scene
            if (enemies.Length == 0 && Bosses.Length >= 0)
            { // there are no fodder but there is bosses turn on the BOSS menu
                this.actionsMenu = GameObject.Find("BOSSActionsMenu");
                GameObject tempMenu = GameObject.Find("ActionsMenu");
                tempMenu.SetActive(false);
            }
            else if(enemies.Length >= 0 && Bosses.Length == 0)
            { // there are no bosses but there is fodder turn on the generic menu
                this.actionsMenu = GameObject.Find("ActionsMenu");
                GameObject tempMenu = GameObject.Find("BOSSActionsMenu");
                tempMenu.SetActive(false);
            }
                this.enemyUnitsMenu = GameObject.Find ("EnemyUnitsMenu");
		}
	}

	public void selectCurrentUnit(GameObject unit) {
		this.currentUnit = unit;
        if (actionsMenu != null)
        {
            this.actionsMenu.SetActive(true);
        }
		this.currentUnit.GetComponent<PlayerUnitAction> ().updateHUD ();
	}

	public void selectAttack(bool physical) {
		this.currentUnit.GetComponent<PlayerUnitAction> ().selectAttack (physical);

		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (true);
	}

	public void attackEnemyTarget(GameObject target) {
		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (false);

		this.currentUnit.GetComponent<PlayerUnitAction>().act (target);
	}
}
