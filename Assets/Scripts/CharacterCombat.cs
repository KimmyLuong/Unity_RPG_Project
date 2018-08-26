using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

	
	CharacterStats myStat;

	public float attackSpeed = 1f;
	public float cooldownTimer = 0;
	public bool inCombat;
	public float lastAttackTime;
	public float combatCooldownTime = 4f;
	
	public float delay = .6f;

	public event System.Action OnAttack;

	private void Start() {
		myStat = GetComponent<CharacterStats>();
	}

	private void Update() {
		cooldownTimer -= Time.deltaTime;
		if(Time.time - lastAttackTime > combatCooldownTime){
			inCombat = false;
		}
	}

	public void Attack(CharacterStats targetStat){
		if(cooldownTimer < 0){
			StartCoroutine(DealDamage(targetStat, delay));
			if(OnAttack != null){
				OnAttack();
			}
			inCombat = true;
			lastAttackTime = Time.time;
			cooldownTimer = attackSpeed * 1f;
		}
	}

	IEnumerator DealDamage(CharacterStats stat, float delay){
		yield return new WaitForSeconds(delay);

		stat.TakeDamage(myStat.damageValue.GetValue());
		if(stat.currentHealth <= 0){
			inCombat = false;
		}
	}
}
