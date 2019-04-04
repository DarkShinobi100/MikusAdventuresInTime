using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour {

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
        {
            UnitStats ownerStats = this.owner.GetComponent<UnitStats>();
            UnitStats targetStats = target.GetComponent<UnitStats>();
            if (ownerStats.mana >= this.manaCost) //got enough Mana to cast?
            {
                float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
                float damage = (this.magicAttack) ? attackMultiplier * ownerStats.magic : attackMultiplier * ownerStats.attack;

                float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
                damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

                this.owner.GetComponent<Animator>().Play(this.attackAnimation);

                targetStats.GetComponent<UnitStatFunctions>().receiveDamage(damage);

                ownerStats.mana -= this.manaCost;
            }
            else
            { //then punch them if not
                float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
                float damage =  attackMultiplier * ownerStats.attack;

                float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
                damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

                this.owner.GetComponent<Animator>().Play(this.attackAnimation);

                targetStats.GetComponent<UnitStatFunctions>().receiveDamage(damage);

            }
        }
	}
}
