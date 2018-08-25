using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public float radius = 3f;

	public PlayerController player;

	private bool isFocused;
	private bool hasInteracted;

	public Transform interactionSpace;

	private void OnDrawGizmos() {
		if(interactionSpace == null){
			interactionSpace = this.transform;
		}
		Gizmos.DrawWireSphere(interactionSpace.position, radius);
	}

	public virtual void Interact(){
		// Debug.Log("Interacting");
		hasInteracted = true;
	}

	private void Update() {
		if(player != null && Vector3.Distance(player.transform.position, interactionSpace.position) < radius){
			if(!hasInteracted){
				Interact();
			}
		}
	}

	public void IsFocused(PlayerController player){
		this.player = player;
		isFocused = true;
	}

	public void Defocus(){
		this.player = null;
		isFocused = false;
		hasInteracted = false;
	}
	
}
