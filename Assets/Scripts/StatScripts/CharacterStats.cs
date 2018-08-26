using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public int maxHealth = 100;
	public int currentHealth { get; private set; }

	public Stats damageValue;
	public Stats armorValue;

	public event System.Action<int, int> OnHealthChanged;

	private void Awake() {
		currentHealth = maxHealth;
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.T)){
			TakeDamage(10);
		}
	}

	public void TakeDamage(int damage){
		damage -= armorValue.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);
		currentHealth -= damage;

		Debug.Log(transform.name + " has taken " + damage + " damage.");
		OnHealthChanged.Invoke(currentHealth, maxHealth);
		if(currentHealth <= 0){
			Die();
		}
	}

	public virtual void Die(){
		Debug.Log(transform.name + " has died.");

	}

}
