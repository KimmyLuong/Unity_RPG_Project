using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerLocomotionController : MonoBehaviour {

	public AnimationClip clipToReplace;

	public AnimationClip[] defaultAnimationClips;
	protected AnimationClip[] currentAnimationClips;

	const float locomotionSmoothingTime = .1f;

	NavMeshAgent agent;
	protected Animator animator;

	CharacterCombat characterCombat;

	public AnimatorOverrideController animatorOverrideController;


	// Use this for initialization
	protected virtual void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
		characterCombat = GetComponent<CharacterCombat>();

		if(animatorOverrideController == null){
			animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
		}
		animator.runtimeAnimatorController = animatorOverrideController;

		currentAnimationClips = defaultAnimationClips;
		characterCombat.OnAttack += OnAttack;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		var speedPercent = agent.velocity.magnitude / agent.speed;
		animator.SetFloat("speedPercent", speedPercent, locomotionSmoothingTime, Time.deltaTime);
		animator.SetBool("inCombat", characterCombat.inCombat);
	}

	protected virtual void OnAttack(){
		animator.SetTrigger("attack");
		int index = Random.Range(0, currentAnimationClips.Length);
		animatorOverrideController[clipToReplace.name] = currentAnimationClips[index];
	}
}
