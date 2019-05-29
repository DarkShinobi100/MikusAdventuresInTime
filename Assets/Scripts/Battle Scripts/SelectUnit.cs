using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectUnit : MonoBehaviour {
    //this script sets up most of the turn systems functions and values
	private GameObject currentUnit;

	private GameObject actionsMenu, enemyUnitsMenu;

	void Awake() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Battle1")
        {
            this.actionsMenu = GameObject.Find("ActionsMenu");
            this.enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
        }
    }

	public void selectCurrentUnit(GameObject unit) { //this function controls the flow of battle and how the menu's are displayed
		this.currentUnit = unit;
        if (actionsMenu != null)
        {
            this.actionsMenu.SetActive(true);
        }
		this.currentUnit.GetComponent<PlayerUnitAction> ().updateHUD ();
	}

	public void selectAttack(bool physical) { //this shows the menu's to allow the player to attack
		this.currentUnit.GetComponent<PlayerUnitAction> ().selectAttack (physical);

		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (true);
	}

	public void attackEnemyTarget(GameObject target) { //this shows the enemy faces to allow the player to attack
		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (false);

		this.currentUnit.GetComponent<PlayerUnitAction>().act (target);
	}
    
    public void setMenus()
    {
        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);
    }
}
