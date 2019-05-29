using UnityEngine;
using System.Collections;

public class ShowUnitHealth : ShowUnitStat {
    //this script tells the slider how much HP a unit has
	override protected float newStatValue() {
        float scaleAmount = (unit.GetComponent<UnitStatFunctions>().health / unit.GetComponent<UnitStatFunctions>().maxHealth) * 100;
        return scaleAmount;
    }
}
