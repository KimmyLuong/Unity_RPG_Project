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

	// Use this for initialization
	void Start () {
		meshAgent = GetComponent<NavMeshAgent> ();
		player = PlayerManager.instance;
		enemyInteractable = GetComponent<EnemyInteractable> ();
		meshAgent.stoppingDistance = enemyInteractable.radius;
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
			meshAgent.stoppingDistance = 2f;
			meshAgent.SetDestination (playerTransform.position);
			Face();
			if(distance < meshAgent.stoppingDistance){
				Debug.Log("Attacking " + player.name);
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