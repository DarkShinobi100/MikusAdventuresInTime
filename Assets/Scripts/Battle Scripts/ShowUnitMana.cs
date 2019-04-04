using UnityEngine;
using System.Collections;

public class ShowUnitMana : ShowUnitStat {

	override protected float newStatValue() {
        float scaleAmount = (unit.GetComponent<UnitStats>().mana / unit.GetComponent<UnitStats>().maxMana) * 100;
        return scaleAmount;
    }
}
