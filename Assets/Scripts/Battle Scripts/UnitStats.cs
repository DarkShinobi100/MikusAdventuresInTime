using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UnitStats : MonoBehaviour
{
    //My Magic Mini class
    //this stores this Units current stats
	[SerializeField]
	protected Animator animator;

	[SerializeField]
    protected GameObject damageTextPrefab;
	[SerializeField]
    protected Vector2 damageTextPosition;

	public float health;
	public float mana;
	public float attack;
	public float magic;
	public float defense;
	public float speed;

	public int nextActTurn;
    public int playerLevel;
    protected bool dead = false;

    protected float currentExperience;

}
