using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Abillity : ScriptableObject
{
	protected Rigidbody rigidbody;

	public abstract event UnityAction AbiliotyEnded;


	public void Init(Rigidbody rigidbody) {
		rigidbody = rigidbody;

	}

	public abstract void UseAbility(AttackState attack);
}
