using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostPlayerTransition : EnemyTransition
{
	public override void Enable()
	{
		throw new System.NotImplementedException();
	}

	[SerializeField] private float minimumlostdistance;

	private void Update()
	{
		if (Vector3.Distance(Player.transform.position, transform.position) > minimumlostdistance)
		{
			NeedTransit = true;
		}
	}
}
