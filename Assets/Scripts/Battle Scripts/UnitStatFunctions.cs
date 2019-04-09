using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UnitStatFunctions : UnitStats, IComparable
{
    public void receiveDamage(float damage)
    {
        this.health -= damage;
        animator.Play("Hit");


        GameObject HUDCanvas = GameObject.Find("HUDCanvas");
        GameObject damageText = Instantiate(this.damageTextPrefab, HUDCanvas.transform) as GameObject;
        damageText.GetComponent<Text>().text = "" + damage;
        damageText.transform.localPosition = this.damageTextPosition;
        damageText.transform.localScale = new Vector2(1.0f, 1.0f);

        if (this.health <= 0)
        {
            this.dead = true;

            //check if the current unit is a friend or foe?
            if (this.tag == "EnemyUnit")
            {
                //set tag to "deadUnit" for tracking during testing
                this.gameObject.tag = "DeadUnit";
                //TODO: play Dead SFX
                //destroy this object, removes from scene and prevents new lists finding it
                Destroy(this.gameObject);
            }
            //if friend
            //change tag to prevents new lists finding it
            this.gameObject.tag = "DeadUnit";
            //TODO: play K'o SFX
            //deactivate it until the end as they are now unconsious
            this.gameObject.SetActive(false);

        }
    }

    public void calculateNextActTurn(int currentTurn)
    {
        this.nextActTurn = currentTurn + (int)Math.Ceiling(100.0f / this.speed);
    }

    public int CompareTo(object otherStats)
    {
        return nextActTurn.CompareTo(((UnitStats)otherStats).nextActTurn);
    }

    public bool isDead()
    {
        return this.dead;
    }

    public void receiveExperience(float experience)
    {
        this.currentExperience += experience;
        levelUp();
    }

    public void levelUp()
    {
        if (playerLevel <= 10)
        {
            //Calculate EXP needed for next level 
            //Using a quadratic function
            // y = a * X ^ 2 + b * X + C
            EXPToNextLevel = 40 * (int)Math.Pow(playerLevel, 2) + 360 * playerLevel + 0;
        }
        else
        {
            //new function Y = a * X^3 + b * X^2 + c * X + d
            //a = -0.4 b=40.4 c=396.0 d=0
            EXPToNextLevel = (int)(-0.4 * Math.Pow(playerLevel, 3) + 40.4 * Math.Pow(playerLevel, 2) + 396.0 * (double)playerLevel + 0);

        }

        if (currentExperience >= EXPToNextLevel)
        {
            //level up!
            ++playerLevel;
            updateStats();
        }
    }

    public void setStats()
    {
        health = maxHealth;
        mana = maxMana;
    }

    public void updateStats()
    {
        health = health * 1.05f;
        mana = mana * 1.05f;
        maxHealth = maxHealth * 1.05f;
        maxMana = maxMana * 1.05f;
        attack = attack * 1.05f;
        magic = magic * 1.05f;
        defense = defense * 1.05f;
        speed = speed * 1.05f;

    }
    public void UpdateEnemyStats()
    {
        //find a player unit
        GameObject player = GameObject.Find("PlayerParty");
        playerLevel = player.GetComponent<UnitStats>().playerLevel;

        if (player != null)
        {
            //scale stats based on players level
            health = health * (1.05f * playerLevel);
            mana = mana * (1.05f * playerLevel);
            maxHealth = maxHealth * (1.05f * playerLevel);
            maxMana = maxMana * (1.05f * playerLevel);
            attack = attack * (1.05f * playerLevel);
            magic = magic * (1.05f * playerLevel);
            defense = defense * (1.05f * playerLevel);
            speed = speed * (1.05f * playerLevel);
        }
    }

}
