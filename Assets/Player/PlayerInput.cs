using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour{
	private Vector3 tapPosition;

	public event UnityAction<Vector2> DirectionChange;
	public event UnityAction PointerUp;

	private void Update()	{
		if (Input.GetMouseButtonDown(0)) {
			tapPosition = Input.mousePosition;
		}
		if (Input.GetMouseButton(0)) {
			DirectionChange?.Invoke(Input.mousePosition - tapPosition);
		}
		if (Input.GetMouseButtonUp(0)){
			PointerUp?.Invoke();
		}
	}
}
