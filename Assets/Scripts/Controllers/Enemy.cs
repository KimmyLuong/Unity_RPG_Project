using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	public int aggroRange = 5;

	NavMeshAgent meshAgent;

	public Transform aggroSpace;

	private PlayerManager player;

	private EnemyInteractable enemyInteractable;

	CharacterCombat myCombat;

	// Use this for initialization
	void Start () {
		meshAgent = GetComponent<NavMeshAgent> ();
		player = PlayerManager.instance;
		enemyInteractable = GetComponent<EnemyInteractable> ();
		meshAgent.stoppingDistance = enemyInteractable.radius;
		myCombat = GetComponent<CharacterCombat>();
	}

	private void OnDrawGizmos () {
		if (aggroSpace == null) {
			aggroSpace = this.transform;
		}
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (aggroSpace.position, aggroRange);
	}

	// Update is called once per frame
	void Update () {
		Transform playerTransform = player.transform;
		float distance = Vector3.Distance (playerTransform.position, transform.position);
		if (distance <= aggroRange) {
			meshAgent.updateRotation = false;
			meshAgent.stoppingDistance = 2;
			Debug.Log("Wtf radius : " + meshAgent.radius);
			meshAgent.SetDestination (playerTransform.position);
			Face();
			Debug.Log("Distance Away: " + distance);
			if(distance <= meshAgent.stoppingDistance){
				CharacterStats playerStat = player.GetComponent<CharacterStats>();
				if(playerStat != null){
					myCombat.Attack(playerStat);
				}
			}
		}
	}

	private void Face(){
		Transform playerTransform = player.transform;
		Vector3 vectorValue = (playerTransform.position - transform.position).normalized;
		var rotationValue = Quaternion.LookRotation (new Vector3 (vectorValue.x, 0f, vectorValue.z));
		transform.rotation = Quaternion.Slerp (transform.rotation, rotationValue, Time.deltaTime * 5f);
	}
}