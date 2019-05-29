using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUnitAction : MonoBehaviour {
    //this script will handle all the players battle actions
	[SerializeField]
	private GameObject physicalAttack;

	[SerializeField]
	private GameObject magicalAttack;

	private GameObject currentAttack;

	[SerializeField]
	private Sprite faceSprite;

	void Awake () {
		this.physicalAttack = Instantiate (this.physicalAttack, this.transform) as GameObject; //set up the prefabs for physical and magical attack types
		this.magicalAttack = Instantiate (this.magicalAttack, this.transform) as GameObject;

		this.physicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;
		this.magicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;

		this.currentAttack = this.physicalAttack; //set the attack value of this script to that of the unit
	}

	public void selectAttack(bool physical) {
		this.currentAttack = (physical) ? this.physicalAttack : this.magicalAttack; //which type of attack are we using
	}

	public void act(GameObject target) {
		this.currentAttack.GetComponent<AttackTarget> ().hit (target);
	}

	public void updateHUD() {
        //update the User interface to match which unit is acting
		GameObject playerUnitFace = GameObject.Find ("playerUnitFace") as GameObject;
		playerUnitFace.GetComponent<Image> ().sprite = this.faceSprite;

        GameObject playerUnitHealthBar = GameObject.Find("playerUnitHealthBar") as GameObject;
        playerUnitHealthBar.GetComponent<ShowUnitHealth>().changeUnit(this.gameObject);

        GameObject playerUnitHealthTextPercent = GameObject.Find("playerUnitHealthTextPercent") as GameObject;
        Text playerHealthText = playerUnitHealthTextPercent.GetComponent<Text>();
        int playerHealthValue = (int)this.GetComponent<UnitStatFunctions>().health;
        playerHealthText.text = playerHealthValue.ToString() + "%";

        GameObject playerUnitManaBar = GameObject.Find ("playerUnitManaBar") as GameObject;
		playerUnitManaBar.GetComponent<ShowUnitMana> ().changeUnit (this.gameObject);

        GameObject playerUnitManaTextPercent = GameObject.Find("playerUnitManaTextPercent") as GameObject;
        Text playerManaText = playerUnitManaTextPercent.GetComponent<Text>();
        int playerManaValue = (int)this.GetComponent<UnitStats>().mana;
        playerManaText.text = playerManaValue.ToString() + "%";

    }
}
