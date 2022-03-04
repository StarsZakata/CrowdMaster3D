using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolowing : MonoBehaviour{
    [SerializeField] private Rigidbody PLAYER;
    [SerializeField] private Vector3 forwardDirection;
    [SerializeField] private float speed;
    [SerializeField] private float angle;
    [SerializeField] private float distance;
    [SerializeField] private float maxVecotLength = 2;

    private Vector3 nextPosition;

	private void Start()	{
        float rotationY = Mathf.Rad2Deg * Mathf.Asin(forwardDirection.x / forwardDirection.magnitude);
        transform.rotation = Quaternion.Euler(angle, rotationY, transform.rotation.eulerAngles.z);
	}

	private void FixedUpdate()	{
        nextPosition = PLAYER.position + Vector3.ClampMagnitude(PLAYER.velocity, maxVecotLength);
        nextPosition += Vector3.up * Mathf.Cos(Mathf.Deg2Rad * angle) * distance;
        nextPosition += -forwardDirection * Mathf.Sin(Mathf.Deg2Rad * angle) * distance;
        transform.position = Vector3.Lerp(transform.position, nextPosition, speed * Time.fixedDeltaTime);
	}
}
