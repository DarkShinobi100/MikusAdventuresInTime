using UnityEngine;
using System.Collections;

public class ShowUnitMana : ShowUnitStat {
    //this script tells the slider how much MP a unit has
    override protected float newStatValue() {
        float scaleAmount = (unit.GetComponent<UnitStatFunctions>().mana / unit.GetComponent<UnitStatFunctions>().maxMana) * 100;
        return scaleAmount;
    }
}
