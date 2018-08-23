using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
	public Image icon;
	ItemObject item;

	public Button deleteButton;

	public void Add(ItemObject newItem){
		item = newItem;
		icon.sprite = item.itemSprite;
		icon.enabled = true;
		deleteButton.interactable = true;
	}

	public void Remove(){
		item = null;
		icon.sprite = null;
		icon.enabled = false;
		deleteButton.interactable = false;
	}

	public void OnRemoveButton(){
		InventoryManager.instance.remove(item);
	}

	public void Use(){
		item.Use();
	}
}
