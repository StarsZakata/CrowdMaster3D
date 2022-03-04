using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
	[SerializeField] private EnemyTransition[] transition;

	public Rigidbody Rigidbody { get; private set; }

	public PlayerStateMachine Player { get; private set; }

	public Animator Animator { get; private set; }

	public void Enter(Rigidbody rigidbody, Animator animator, PlayerStateMachine player)
	{
		if (enabled == false)
		{
			Rigidbody = rigidbody;
			Animator = animator;
			enabled = true;

			foreach (var transition in transition)
			{
				transition.enabled = true;
				transition.Init(Player);
			}
		}
	}

	public void Exit()
	{
		if (enabled == true)
		{
			foreach (var transition in transition)
			{
				transition.enabled = false;
				
			}
			enabled = false;
		}
	}

	public EnemyState GetNextState()
	{
		foreach (var transition in transition)
		{
			if (transition.NeedTranst)
			{
				return transition.TargetState;
			}
		}
		return null;
	}
}
