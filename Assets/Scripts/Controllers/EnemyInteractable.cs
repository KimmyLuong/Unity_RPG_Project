using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractable : Interactable {


	public override void Interact(){
		base.Interact();
		Debug.Log("Enemy interacting with me");
	}
	
}
