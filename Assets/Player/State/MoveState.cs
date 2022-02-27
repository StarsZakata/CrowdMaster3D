using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MoveState : PlayerState {

	[SerializeField] private PlayerInput playerInput;
	[SerializeField] private float maxSppeed;

	[SerializeField] private float speedRatio;

	private void OnEnable()	{
		playerInput.DirectionChange += OnDirectionChanges;
	}

	private void OnDisable(){
		playerInput.DirectionChange -= OnDirectionChanges;
	}

	private void OnDirectionChanges(Vector2 direction) {
		Rigidbody.velocity = new Vector3(direction.x, 0, direction.y) * speedRatio;
		if (Rigidbody.velocity.magnitude > maxSppeed) {
			Rigidbody.velocity *= maxSppeed / Rigidbody.velocity.magnitude;
		}
		if (Rigidbody.velocity.magnitude != 0) {
			Rigidbody.MoveRotation(Quaternion.LookRotation(Rigidbody.velocity, Vector3.up));
		}
	}
}
