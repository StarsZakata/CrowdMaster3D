using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApprochedPlayerTransition : EnemyTransition
{
    [SerializeField] private float approachDistance;

	public override void Enable()
	{
		throw new System.NotImplementedException();
	}

	private void Update()
	{
		if (Vector3.Distance(Player.transform.position, transform.position) < approachDistance)
		{
			NeedTransit = true;
		}
	}
}
