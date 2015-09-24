using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody playerRigidbody;
	Animator playerAnimator;

	public float movementSpeed = 6f; //= 6.0
	public float turnSpeed = 65f;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent <Rigidbody> ();
		playerAnimator = GetComponent <Animator> ();
	
	}
	
	// because some frames take longer than others, so multiply movement with Time.deltaTime
	void Update () {
		//Input from arrow keys:
		float forwardMovement = Input.GetAxis ("Vertical");
		float turnMovement = Input.GetAxis ("Horizontal");

		//Whether player is "walking" or "idle"
		if (forwardMovement == 0 && turnMovement == 0) {
			playerAnimator.SetBool ("IsWalking", false); //links to animator to make player idle, etc.
		} else {
			playerAnimator.SetBool ("IsWalking", true);
		}

		//Player forward motion:
		Vector3 movement = forwardMovement * transform.forward; //makes player move forward
		movement = movement.normalized * Time.deltaTime * movementSpeed; //normalizes movement vector so don't move faster diagonally
		playerRigidbody.MovePosition (transform.position + movement);

		//Player turning motion:
		float currentRotation = transform.rotation.eulerAngles.y;
		float targetAngle = currentRotation + turnMovement * Time.deltaTime * turnSpeed;
		Quaternion newRotation = Quaternion.Euler (new Vector3 (0, targetAngle, 0));
		playerRigidbody.MoveRotation (newRotation); //turns the player by targetAngle in Quaternions

	}
}
