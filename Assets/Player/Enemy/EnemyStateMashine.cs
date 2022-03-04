using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStateMashine : MonoBehaviour, IDamageable
{
	[SerializeField] private EnemyState firstState;
	[SerializeField] private BrokenState brokenState;
	[SerializeField] private HealthContainer helatContainer;


	private EnemyState currentState;

	private Rigidbody rigidbody;
	private Animator animator;


	private float minDamage;
	public PlayerStateMachine Player { get; private set;  }
	public event UnityAction<EnemyStateMashine> Died;

	private void OnEnable()
	{
		helatContainer.Deid += OnEnemyDie;
	}

	private void OnDisable()
	{
		helatContainer.Deid -= OnEnemyDie;
	}

	private void OnEnemyDie() {
		enabled = false;
		rigidbody.constraints = RigidbodyConstraints.None;
		Died?.Invoke(this);
	}


	public void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		Player = FindObjectOfType<PlayerStateMachine>();
	}

	public void Start()
	{
		currentState = firstState;
		currentState.Enter(rigidbody, animator, Player);
	}

	private void Update()
	{
		if (currentState == null)
		{
			return;
		}
		EnemyState nextState = currentState.GetNextState();
		if (nextState != null)
		{
			Transit(nextState);
		}

	}
	private void Transit(EnemyState nextState)
	{
		if (currentState != null)
		{
			currentState.Exit();
		}
		currentState = nextState;
		if (currentState != null)
		{
			currentState.Enter(rigidbody, animator, Player);
		}
	}

	public bool ApplyyDamage(Rigidbody rigidbody, float force)
	{
		if (force > minDamage && currentState != brokenState) {
			helatContainer.TakeDamage((int)force);
			Transit(brokenState);
			brokenState.ApplyDamage(rigidbody, force);
			return true;
		}
		return false;
	}
}
