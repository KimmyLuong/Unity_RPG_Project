using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

	NavMeshAgent agent;

	Interactable focus;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update() {
		if(focus != null){
			MoveToPoint(focus.interactionSpace.position);
			Vector3 vectorValue= (focus.interactionSpace.position - transform.position).normalized;
			var rotationValue = Quaternion.LookRotation(new Vector3(vectorValue.x, 0f, vectorValue.z));
			transform.rotation = Quaternion.Slerp(transform.rotation, rotationValue, Time.deltaTime * 5f);
		}
		else{
			agent.updateRotation = true;
		}
		
	}
	
	public void MoveToPoint (Vector3 point){
		agent.SetDestination(point);
	}

	public void SetFocus(Interactable focus){
		agent.stoppingDistance = focus.radius * .8f;
		this.focus = focus;
		agent.updateRotation = false;
	}

	public void StopFocus(){
		agent.stoppingDistance = 0;
		this.focus = null;
	}
}
