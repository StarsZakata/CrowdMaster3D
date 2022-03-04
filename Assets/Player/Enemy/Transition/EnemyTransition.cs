using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTransition : PlayerTransition
{
	[SerializeField] private EnemyState targetState;

	public EnemyState TargetState => targetState;
	protected PlayerStateMachine Player { get; private set; }
	public bool NeedTransit { get; protected set; }


	public void Init(PlayerStateMachine player)
	{
		Player = player;
	}

	protected virtual void OnEnable()
	{
		NeedTransit = false;
	}

}
