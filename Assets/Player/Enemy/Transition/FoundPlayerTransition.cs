using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundPlayerTransition : EnemyTransition
{
	[SerializeField] private float foundDistance;

	public override void Enable()
	{
		throw new System.NotImplementedException();
	}

	private void Update()
	{
		if (Vector3.Distance(Player.transform.position, transform.position) < foundDistance) {
			NeedTransit = true;
		}
	}



}
