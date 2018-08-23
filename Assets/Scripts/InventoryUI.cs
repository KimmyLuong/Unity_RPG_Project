using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

	public GameObject inventoryParent;

	InventoryManager inventory;
	InventorySlot[] inventorySlot;
	// Use this for initialization
	void Start () {
		inventory = InventoryManager.instance;
		inventory.onItemChangedCallBack += UpdateUI;

		inventorySlot = inventoryParent.GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Inventory")){
			Debug.Log("I'm being pressed");
			inventoryParent.gameObject.SetActive(!inventoryParent.gameObject.activeSelf);
		}
	}

	void UpdateUI(){
		for (int i = 0; i < inventorySlot.Length; i++)
		{
			if(i < inventory.itemList.Count){
				inventorySlot[i].Add(inventory.itemList[i]);
			}
			else{
				inventorySlot[i].Remove();
			}
		}
	}
}
