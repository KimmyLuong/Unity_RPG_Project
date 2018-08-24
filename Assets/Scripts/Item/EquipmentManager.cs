using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentManager : MonoBehaviour {

	#region Singleton

	public static EquipmentManager instance;

	public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem);
	public OnEquipmentChange onEquipmentChangedCallback;

	public SkinnedMeshRenderer targetMesh;

	Equipment[] equipmentArray;
	public Equipment[] defaultItemArray;

	SkinnedMeshRenderer[] meshArray;


	private void Awake() {
		if(instance == null){
			Debug.Log("EquipmentManager instantiation");
			instance = this;
		}
		else{
			Debug.LogError("WARNING TOO MANY EQUIPMENT INSTANCES");
		}
	}

	#endregion


	private void Start() {
		int enumeratorSize = Enum.GetNames(typeof(EquipmentEnumerator)).Length;
		equipmentArray = new Equipment[enumeratorSize];
		meshArray = new SkinnedMeshRenderer[enumeratorSize];
		EquipDefaultItems();
	}

	public void equipItem(Equipment newItem){
		int equipmentIndex = (int)newItem.equipmentEnumerator;
		Equipment oldItem = UnequipItem(equipmentArray[equipmentIndex]);
		if(onEquipmentChangedCallback != null){
			onEquipmentChangedCallback(newItem, oldItem);
		}
		
		SetEquipmentMeshBlendShape(newItem, 100);

		equipmentArray[equipmentIndex] = newItem;
		SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
		newMesh.transform.parent = targetMesh.transform;
		newMesh.bones = targetMesh.bones;
		newMesh.rootBone = targetMesh.rootBone;
		meshArray[equipmentIndex] = newMesh;
	}

	public Equipment UnequipItem(Equipment oldItem){
		if(oldItem == null){
			return null;
		}
		int equipmentIndex = (int)oldItem.equipmentEnumerator;
		if(equipmentArray[equipmentIndex] != null){
			InventoryManager.instance.Add(oldItem);
			equipmentArray[equipmentIndex] = null;

			if(meshArray[equipmentIndex] != null){
				Destroy(meshArray[equipmentIndex].gameObject);
			}

			SetEquipmentMeshBlendShape(oldItem, 0);

			if(onEquipmentChangedCallback != null){
				onEquipmentChangedCallback(null, oldItem);
			}
		}

		if(oldItem.defaultItem){
			return null;
		}

		return oldItem;
	}

	public void UnequipAllItems(){
		for (int i = 0; i < equipmentArray.Length; i++)
		{
			UnequipItem(equipmentArray[i]);
		}
		EquipDefaultItems();
	}

	void SetEquipmentMeshBlendShape(Equipment item, int weight){
		foreach(EquipmentMeshBlendShape itemMesh in item.meshBlendShape){
			targetMesh.SetBlendShapeWeight((int)itemMesh, weight);
		}
	}

	void EquipDefaultItems(){
		foreach(Equipment item in defaultItemArray){
			equipItem(item);
		}
	}

	private void Update() {
		if(Input.GetButtonDown("UnequipAll")){
			UnequipAllItems();
		}
	}
}
