using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour {

	public Transform target;

	public GameObject healthPrefab;

	Image healthSlider;

	Transform ui;

	Camera camera;

	public float cooldownTime = 5f;

	float lastAttackTime;

	private void Start () {
		camera = Camera.main;
		GetComponentInParent<CharacterStats> ().OnHealthChanged += OnHealthChanged;
		foreach (Canvas canvas in FindObjectsOfType<Canvas> ()) {
			if (canvas.renderMode == RenderMode.WorldSpace) {
				ui = Instantiate (healthPrefab, canvas.transform).transform;
				healthSlider = ui.GetChild (0).GetComponent<Image> ();
				ui.gameObject.SetActive(false);
				break;
			}
		}
	}

	private void LateUpdate () {
		if (ui != null) {
			ui.position = target.position;
			ui.forward = -camera.transform.forward;
			if(Time.time - lastAttackTime > cooldownTime){
				ui.gameObject.SetActive(false);
			}
		}
	}

	void OnHealthChanged (int currentHealth, int maxHealth) {
		if (ui != null) {
			ui.gameObject.SetActive(true);
			float healthPercentage = currentHealth / (float) maxHealth;
			healthSlider.fillAmount = healthPercentage;
			lastAttackTime = Time.time;
			if (currentHealth <= 0) {
				Destroy (ui.gameObject);
			}
		}
	}

}