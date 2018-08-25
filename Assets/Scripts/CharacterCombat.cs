using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

	
	CharacterStats myStat;

	public float attackSpeed = 1f;
	public float cooldownTimer = 0;
	
	public float delay = .6f;

	public event System.Action OnAttack;

	private void Start() {
		myStat = GetComponent<CharacterStats>();
	}

	private void Update() {
		cooldownTimer -= Time.deltaTime;
	}

	public void Attack(CharacterStats targetStat){
		if(cooldownTimer < 0){
			StartCoroutine(DealDamage(targetStat, delay));
			if(OnAttack != null){
				OnAttack();
			}
			cooldownTimer = attackSpeed * 1f;
		}
	}

	IEnumerator DealDamage(CharacterStats stat, float delay){
		yield return new WaitForSeconds(delay);

		stat.TakeDamage(myStat.damageValue.GetValue());
	}
}
