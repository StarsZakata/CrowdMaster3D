using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerStateMachine : MonoBehaviour{
    [SerializeField] private PlayerState firstState;

	private PlayerState currentState;
    private Rigidbody rigidbody;
    private Animator animator;

	public void Awake()	{
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}

	public void Start()	{
		currentState = firstState;
		currentState.Enter(rigidbody, animator);
	}

	private void Update()	{
		if (currentState != null) {
			return;
		}
		PlayerState nextState = currentState.GetNextState();
		if (nextState != null) {
			Transit(nextState);
		}

	}
	private void Transit(PlayerState nextState) {
		if (currentState != null) {
			currentState.Exit();
		}
		currentState = nextState;
		if (currentState != null) {
			currentState.Enter(rigidbody, animator);
		}
	}
}
