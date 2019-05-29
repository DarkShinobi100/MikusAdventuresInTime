using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour {
    //this script allows the player to select an enemy from the amount remaining
	public GameObject owner;

	[SerializeField]
	private string attackAnimation;

	[SerializeField]
	private bool magicAttack;

	[SerializeField]
	private float manaCost;

	[SerializeField]
	private float minAttackMultiplier;

	[SerializeField]
	private float maxAttackMultiplier;

	[SerializeField]
	private float minDefenseMultiplier;

	[SerializeField]
	private float maxDefenseMultiplier;
	
	public void hit(GameObject target) {
        if (target != null)
        { //if we are attacking how are we attacking?
            UnitStats ownerStats = this.owner.GetComponent<UnitStats>();
            UnitStats targetStats = target.GetComponent<UnitStats>();
            if (ownerStats.mana >= this.manaCost) //got enough Mana to cast?
            {//calculate the attack value of the attacking unit with a crit chance on top
                float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
                float damage = (this.magicAttack) ? attackMultiplier * ownerStats.magic : attackMultiplier * ownerStats.attack;

                float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
                //calculate the damage delt to the target by taking your attack value away from the defence value
                damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

                this.owner.GetComponent<Animator>().Play(this.attackAnimation); //play the attacking animation

                targetStats.GetComponent<UnitStatFunctions>().receiveDamage(damage); //tell the target that they have been attacked and to react

                ownerStats.mana -= this.manaCost; //reduce this units mana value as we used magic
            }
            else
            { //then punch them if not
                //calculate the attack value of the attacking unit with a crit chance on top
                float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
                float damage =  attackMultiplier * ownerStats.attack;
                //calculate the damage delt to the target by taking your attack value away from the defence value
                float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
                damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

                this.owner.GetComponent<Animator>().Play(this.attackAnimation); //play the attacking animation

                targetStats.GetComponent<UnitStatFunctions>().receiveDamage(damage); //tell the target that they have been attacked and to react

            }
        }
	}
}
