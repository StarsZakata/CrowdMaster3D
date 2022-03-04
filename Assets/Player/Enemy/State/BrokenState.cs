using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrokenState : EnemyState
{

	public event UnityAction Died;
	[SerializeField] private float fallDistance;

	public void ApplyDamage(Rigidbody attachedBody, float force) {
		//Animation.SetTrigger("fall");
		Vector3 direction = (transform.position - attachedBody.position);
		direction.y = 0;
		Rigidbody.AddForce(direction.normalized * force, ForceMode.Impulse);
	}

	private void FixedUpdate()
	{
		Ray ray = new Ray(transform.position + Vector3.up, Vector3.down	);
		if (Physics.Raycast(ray, fallDistance) == false) {
			Rigidbody.constraints = RigidbodyConstraints.None;
			Died?.Invoke();
		}
	}


	private void OnTriggerStay(Collider other)
	{
		if (enabled == false) {
			return;
		}
		if (other.TryGetComponent(out IDamageable damagable)) {
			damagable.ApplyyDamage(Rigidbody, Rigidbody.velocity.magnitude);
		}
	}


}
