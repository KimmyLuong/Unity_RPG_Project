using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : PlayerLocomotionController {

public WeaponAnimations[] weaponAnimations;
Dictionary<Equipment, AnimationClip[]> weaponAnimationsDictionary;

	protected override void Start() {
		base.Start();
		EquipmentManager.instance.onEquipmentChangedCallback += OnEquipmentChanged;
		weaponAnimationsDictionary = new Dictionary<Equipment, AnimationClip[]>();
		foreach (WeaponAnimations animation in weaponAnimations)
		{
			weaponAnimationsDictionary.Add(animation.weapon, animation.clips);
		}
	}

	public void OnEquipmentChanged(Equipment newItem, Equipment oldItem){
		if(newItem != null && newItem.equipmentEnumerator == EquipmentEnumerator.Weapon){
			animator.SetLayerWeight(1,1);
			if(weaponAnimationsDictionary.ContainsKey(newItem)){
				currentAnimationClips = weaponAnimationsDictionary[newItem];
			}
		}
		else if(oldItem != null && oldItem.equipmentEnumerator == EquipmentEnumerator.Weapon){
			animator.SetLayerWeight(1,0);
			currentAnimationClips = defaultAnimationClips;
		}

		if(newItem != null && newItem.equipmentEnumerator == EquipmentEnumerator.Shield){
			animator.SetLayerWeight(2,1);
		}
		else if(oldItem != null && oldItem.equipmentEnumerator == EquipmentEnumerator.Shield){
			animator.SetLayerWeight(2,0);
		}
	}

	[System.Serializable]
	public struct WeaponAnimations{
		public Equipment weapon;
		public AnimationClip[] clips;
	}
}
