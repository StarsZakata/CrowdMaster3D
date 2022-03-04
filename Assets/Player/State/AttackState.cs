using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackState : PlayerState {
	[SerializeField] private StaminaAccumulator staminaAccumulator;
	private Abillity currentAbility;

	///
	public event UnityAction<IDamageable> CollisionDetected;
	
	public event UnityAction AbilityEnded;

	private void OnEnable()
	{
		currentAbility = staminaAccumulator.GetAbbility();
		currentAbility.AbiliotyEnded += OnAbbilityEnded;


		currentAbility.UseAbility(this);
	}

	private void OnDisable()
	{
		currentAbility.AbiliotyEnded -= OnAbbilityEnded;
	}


	private void OnAbbilityEnded() {
		AbilityEnded?.Invoke();
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out IDamageable damagble))
			CollisionDetected?.Invoke(damagble);
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent(out IDamageable damagble))
			CollisionDetected?.Invoke(damagble);
	}

	private void Update()
	{
		
	}
}
