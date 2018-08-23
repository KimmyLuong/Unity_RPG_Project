using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CharacterStats {

	private void Start() {
		EquipmentManager.instance.onEquipmentChangedCallback += OnEquipmentChangedCallback;
	}

	private void OnEquipmentChangedCallback(Equipment newItem, Equipment oldItem){
		if(newItem != null){
			armorValue.AddValue(newItem.armorValue);
			damageValue.AddValue(newItem.damageValue);
		}

		if(oldItem != null){
			armorValue.RemoveValue(oldItem.armorValue);
			damageValue.RemoveValue(oldItem.damageValue);
		}
	}
}
