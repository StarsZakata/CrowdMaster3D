using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(HealthContainer))]
public class PlayerStateMachine : MonoBehaviour{
    [SerializeField] private PlayerState firstState;

	private PlayerState currentState;
    private Rigidbody rigidbody;
    private Animator animator;
	private HealthContainer health;

	public event UnityAction Damaged;


	private void OnEnable()
	{
		health.Deid += OnDied;
	}

	private void OnDisable()
	{
		health.Deid -= OnDied;
	}
	
	private void OnDied() {
		enabled = false;
		//animator.SetTrigger("broken");
	}


	public void Awake()	{


		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		health = GetComponent<HealthContainer>();
	}

	public void Start()	{
		currentState = firstState;
		currentState.Enter(rigidbody, animator);
	}

	private void Update()	{
		if (currentState == null) {
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

	public void ApplyDamage(float damage) {
		Damaged?.Invoke();
		health.TakeDamage((int)damage);
	}

}
