using UnityEngine;
using System.Collections;

public class ShowUnitHealth : ShowUnitStat {

	override protected float newStatValue() {
        float scaleAmount = (unit.GetComponent<UnitStatFunctions>().health / unit.GetComponent<UnitStatFunctions>().maxHealth) * 100;
        return scaleAmount;
    }
}
