using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "New Hand Ability", menuName = "Player/Abilities/Hand", order = 51)]
public class HandAbility : Abillity {
	[SerializeField] private float attackForce;
	[SerializeField] private float UsefulTime;

	private AttackState state;
	private Coroutine coroutine;


	public override event UnityAction AbiliotyEnded;

	public override void UseAbility(AttackState attack)	{
		if (coroutine != null) {
			Reset();
		}
		state = attack;
		///
		coroutine = state.StartCoroutine(Attack(state));
		state.CollisionDetected += OnPlayerAttack;
	}

	private void OnPlayerAttack(IDamageable damagble) {
		if (damagble.ApplyyDamage(state.Rigidbody, attackForce) == false) {
			return;
		}
		state.Rigidbody.velocity /= 2;
	}
	
	private IEnumerator Attack(AttackState state) {
		float time = UsefulTime;
		while (time > 0) {
			state.Rigidbody.velocity = state.Rigidbody.velocity.normalized * attackForce;
			time -= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		Reset();
		AbiliotyEnded?.Invoke();
	}


	private void Reset() {
		state.Rigidbody.velocity = Vector3.zero;
		state.StopCoroutine(coroutine);
		coroutine = null;
		state.CollisionDetected -= OnPlayerAttack;
	}
}
