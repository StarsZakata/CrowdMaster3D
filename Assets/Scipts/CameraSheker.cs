using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSheker : MonoBehaviour{
	[SerializeField] private PlayerStateMachine Player;
	[SerializeField] private float Speed;
	[SerializeField] private int Range;

	private Coroutine coroutine;

	private void OnEnable()	{
		Player.Damaged += OnPlayerDamage;
	}

	private void OnDisable()	{
		Player.Damaged -= OnPlayerDamage;
	}

	private void OnPlayerDamage() {
		if (coroutine != null) {
			StopCoroutine(coroutine);
		}
		coroutine = StartCoroutine(Shake());
	}

	private IEnumerator Shake() {
		int shakeRange = Range;
		Quaternion targetRotation;
		while (shakeRange != 0){
			targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, shakeRange);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Speed * Time.deltaTime);
			if (transform.rotation == targetRotation) { 
				shakeRange = (Mathf.Abs(shakeRange) - 1) * -1;
			}
			yield return new WaitForEndOfFrame();
		}
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.eulerAngles.y, 0);
		coroutine = null;
	}
}
