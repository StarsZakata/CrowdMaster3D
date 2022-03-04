using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour {
	[SerializeField] private PlayerTransition[] transition;

	public Rigidbody Rigidbody { get; private set; }
	public Animator Animator { get; private set; }

	public void Enter(Rigidbody rigidbody, Animator animator)	{
		if (enabled == false) {
			Rigidbody = rigidbody;
			Animator = animator;
			enabled = true;

			foreach (var transition in transition) {
				transition.enabled = true;
			}
		}
	}

	public void Exit() {
		if (enabled == true) {
			foreach (var transition in transition) {
				transition.enabled = false;
			}
			enabled = false;
		}
	}

	public PlayerState GetNextState() {
		foreach (var transition in transition) {
			if (transition.NeedTranst) {
				return transition.TargetState;
			}
		}
		return null;
	}
}
