using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChaseState : EnemyState
{
	private NavMeshAgent Agent;


	private void Awake()
	{
		Agent = GetComponent<NavMeshAgent>();
	}

	private void OnEnable()
	{
		Agent.enabled = true;
		//Animator.SetTrigger("run");
	}

	private void OnDisable()
	{
		Agent.enabled = false;
	}

	private void Update()
	{
		Agent.SetDestination(Player.transform.position);
	}

}
