using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAttackState : EnemyState
{
	[SerializeField] private float attackForce;
	[SerializeField] private float AttackDelay;
	private Coroutine coroutine;

	private void OnEnable()
	{
		coroutine = StartCoroutine(Attack());
	}

	private void OnDisable()
	{
		StopCoroutine(coroutine);
	}

	private IEnumerator Attack() {
		while (enabled) {
			Animator.SetTrigger("attack");
			yield return new WaitForSeconds(AttackDelay);
			Player.ApplyDamage(attackForce);
		}
	}
}
