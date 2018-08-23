using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName="Inventory/Item")]
public class ItemObject : ScriptableObject {

	new public string name = "Item Name";
	public Sprite itemSprite = null;
	public bool defaultItem = false;

	public virtual void Use(){
		Debug.Log("Using item " + name);
	}

}
