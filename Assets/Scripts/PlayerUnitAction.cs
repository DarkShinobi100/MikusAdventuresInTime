using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUnitAction : MonoBehaviour {

	[SerializeField]
	private GameObject physicalAttack;

	[SerializeField]
	private GameObject magicalAttack;

	private GameObject currentAttack;

	[SerializeField]
	private Sprite faceSprite;

	void Awake () {
		this.physicalAttack = Instantiate (this.physicalAttack, this.transform) as GameObject;
		this.magicalAttack = Instantiate (this.magicalAttack, this.transform) as GameObject;

		this.physicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;
		this.magicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;

		this.currentAttack = this.physicalAttack;
	}

	public void selectAttack(bool physical) {
		this.currentAttack = (physical) ? this.physicalAttack : this.magicalAttack;
	}

	public void act(GameObject target) {
		this.currentAttack.GetComponent<AttackTarget> ().hit (target);
	}

	public void updateHUD() {
		GameObject playerUnitFace = GameObject.Find ("playerUnitFace") as GameObject;
		playerUnitFace.GetComponent<Image> ().sprite = this.faceSprite;

		GameObject playerUnitHealthBar = GameObject.Find ("playerUnitHealthBar") as GameObject;
		playerUnitHealthBar.GetComponent<ShowUnitHealth> ().changeUnit (this.gameObject);

        GameObject playerUnitHealthTextPercent = GameObject.Find("playerUnitHealthTextPercent") as GameObject;
        playerUnitHealthBar.GetComponent<ShowUnitHealth>().changeUnit(this.gameObject);

        GameObject playerUnitManaBar = GameObject.Find ("playerUnitManaBar") as GameObject;
		playerUnitManaBar.GetComponent<ShowUnitMana> ().changeUnit (this.gameObject);

        GameObject playerUnitManaTextPercent = GameObject.Find("playerUnitManaTextPercent") as GameObject;
        playerUnitManaBar.GetComponent<ShowUnitMana>().changeUnit(this.gameObject);
    }
}
