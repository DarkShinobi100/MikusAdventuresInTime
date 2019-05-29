using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateEnemyMenuItems : MonoBehaviour {
    //this script will display the enemy units faces to allow the player to pick an attack target
	[SerializeField]
	private GameObject targetEnemyUnitPrefab;

	[SerializeField]
	private Sprite menuItemSprite;

	[SerializeField]
	private Vector2 initialPosition, itemDimensions;

	[SerializeField]
	private KillEnemy killEnemyScript;

	// Use this for initialization
	void Awake () {

		GameObject enemyUnitsMenu = GameObject.Find ("EnemyUnitsMenu");

        //look for other enemy pictures and move if overlapping
		GameObject[] existingItems = GameObject.FindGameObjectsWithTag ("TargetEnemyUnit");
		Vector2 nextPosition = new Vector2 (this.initialPosition.x + (existingItems.Length * this.itemDimensions.x), this.initialPosition.y);

        //spawn the enemy units faces in a row below the battle map
		GameObject targetEnemyUnit = Instantiate (this.targetEnemyUnitPrefab, enemyUnitsMenu.transform) as GameObject;
		targetEnemyUnit.name = "Target" + this.gameObject.name;
		targetEnemyUnit.transform.localPosition = nextPosition; //move the icons along by a set amount if they are overlapping
		targetEnemyUnit.transform.localScale = new Vector2 (0.7f, 0.7f);
		targetEnemyUnit.GetComponent<Button> ().onClick.AddListener (() => 
			selectEnemyTarget());
		targetEnemyUnit.GetComponent<Image> ().sprite = this.menuItemSprite;

		killEnemyScript.menuItem = targetEnemyUnit;
	}

	public void selectEnemyTarget() {
        //run the attack enemy target function once we have an attack target
		GameObject partyData = GameObject.Find ("PlayerParty");
		partyData.GetComponent<SelectUnit> ().attackEnemyTarget (this.gameObject);
	}

}
