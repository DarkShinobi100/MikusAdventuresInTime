using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UnitStats : MonoBehaviour, IComparable {

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private GameObject damageTextPrefab;
	[SerializeField]
	private Vector2 damageTextPosition;

	public float health;
	public float mana;
	public float attack;
	public float magic;
	public float defense;
	public float speed;

	public int nextActTurn;

	private bool dead = false;

	private float currentExperience;

	void Start() {
		
	}

	public void receiveDamage(float damage) {
		this.health -= damage;
		animator.Play ("Hit");

		GameObject HUDCanvas = GameObject.Find ("HUDCanvas");
		GameObject damageText = Instantiate (this.damageTextPrefab, HUDCanvas.transform) as GameObject;
		damageText.GetComponent<Text> ().text = "" + damage;
		damageText.transform.localPosition = this.damageTextPosition;
		damageText.transform.localScale = new Vector2 (1.0f, 1.0f);

		if (this.health <= 0) {
			this.dead = true;

            //check if the current unit is a friend or foe?
            if (this.tag == "EnemyUnit")
            {
                //set tag to "deadUnit" for tracking during testing
                this.gameObject.tag = "DeadUnit";
                //destroy this object, removes from scene and prevents new lists finding it
                Destroy(this.gameObject);
            }
            //if friend
            //change tag to prevents new lists finding it
            this.gameObject.tag = "DeadUnit";
            //deactivate it until the end as they are now unconsious
            this.gameObject.SetActive(false);

		}
	}

	public void calculateNextActTurn(int currentTurn) {
		this.nextActTurn = currentTurn + (int)Math.Ceiling(100.0f / this.speed);
	}

	public int CompareTo(object otherStats) {
		return nextActTurn.CompareTo (((UnitStats)otherStats).nextActTurn);
	}

	public bool isDead() {
		return this.dead;
	}

	public void receiveExperience(float experience) {
		this.currentExperience += experience;
	}
}
