using UnityEngine;

public class ItemPickup : Interactable {

	public ItemObject item;

	public override void Interact(){
		base.Interact();
		PickUp();
		
	}

	void PickUp(){
		Debug.Log("Picked up " + item.name);
		bool wasPickedUp = InventoryManager.instance.Add(item);
		if(wasPickedUp){
			Destroy(gameObject);	
		} 
	}
}
