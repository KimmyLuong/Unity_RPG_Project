using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	public LayerMask movementMask;

	Camera cam;
	PlayerMotor motor;
	public Interactable interactable;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		if(EventSystem.current.IsPointerOverGameObject()){
			return;
		}
		if(Input.GetMouseButton(0)){
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 100, movementMask)){

				Debug.Log("We hit" + hit.collider.name + " " + hit.point);
				//  Move our player to what we hit
				motor.MoveToPoint(hit.point);
				// Stop focussing any objects
				motor.StopFocus();
				if(interactable != null){
					interactable.Defocus();
					interactable = null;
				}
			}
		}

		if(Input.GetMouseButton(1)){
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 100)){

				interactable = hit.transform.GetComponent<Interactable>();

				if(interactable != null){
					Debug.Log("I'm working");
					motor.SetFocus(interactable);
					interactable.IsFocused(this);
				}
				// Stop focussing any objects
			}
		}
	}
}
