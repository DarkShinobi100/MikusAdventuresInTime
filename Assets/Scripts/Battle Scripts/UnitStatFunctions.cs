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
        if(this.currentExperience >= 100)
        {
            playerLevel += 1;
        }
    }

    public void setStats(float HP, float MP)
    {
        health = HP;
        mana = MP;
    }

}
