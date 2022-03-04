using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
	public bool ApplyyDamage(Rigidbody rigidbody, float force)
	{
		Debug.Log("Corobka");
		return true;
	}
}
