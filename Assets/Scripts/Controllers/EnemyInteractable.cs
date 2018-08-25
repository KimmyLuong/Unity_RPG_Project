using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractable : Interactable {

	PlayerManager playerManager;

	CharacterStats myStats;

	private void Start() {
		playerManager = PlayerManager.instance;
		myStats = GetComponent<CharacterStats>();
	}
	public override void Interact(){
		base.Interact();
		CharacterCombat playerCombat = playerManager.GetComponent<CharacterCombat>();
		if(playerCombat != null){
			playerCombat.Attack(myStats);
		}
	}
	
}
