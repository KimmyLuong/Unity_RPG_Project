using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public int inventorySizeLimit = 20;

	public List<ItemObject> itemList = new List<ItemObject> ();

	#region Singleton

	public static InventoryManager instance;

	public delegate void onItemChanged ();
	public onItemChanged onItemChangedCallBack;

	private void Awake () {
		if (instance != null) {
			Debug.LogWarning ("Instance already exists!");
			return;
		}
		instance = this;
	}

	#endregion

	public bool Add (ItemObject item) {
		if (!item.defaultItem) {
			if (itemList.Count < inventorySizeLimit) {
				itemList.Add (item);
				if (onItemChangedCallBack != null) {
					onItemChangedCallBack.Invoke ();
				}
				return true;
			} else {
				Debug.Log ("Not enough inventory space");
			}

		}
		return false;
	}

	public void remove (ItemObject item) {
		itemList.Remove(item);
		if (onItemChangedCallBack != null) {
			onItemChangedCallBack.Invoke ();
		}
	}
}