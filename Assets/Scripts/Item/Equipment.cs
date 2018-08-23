using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Equipment", menuName="Inventory/Equipment")]
public class Equipment : ItemObject {

	public int damageValue;
	public int armorValue;

	public EquipmentMeshBlendShape[] meshBlendShape;

	public EquipmentEnumerator equipmentEnumerator;
	public SkinnedMeshRenderer mesh;

	override public void Use(){
		base.Use();
		EquipmentManager.instance.equipItem(this);
		InventoryManager.instance.remove(this);
	}

	
}

public enum EquipmentEnumerator{
		Head, Chest, Leg, Weapon, Shield, Feet
	}

public enum EquipmentMeshBlendShape{
	Legs, Arm, Torso
}
