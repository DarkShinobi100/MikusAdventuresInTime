using UnityEngine;
using System.Collections;

public class ShowUnitMana : ShowUnitStat {

	override protected float newStatValue() {
		return unit.GetComponent<UnitStats> ().mana;
	}
}
