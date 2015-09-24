using UnityEngine;
using System.Collections;

public class PlaneBehavior : MonoBehaviour {

	Rigidbody planeRigidbody;
	public float movementSpeed = 6f; //= 6.0
	public float turnSpeed = 65f;

	// Use this for initialization
	void Start () {
		planeRigidbody = GetComponent <Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		float zRotation = Input.GetAxis ("Vertical");
		float xRotation = Input.GetAxis ("Horizontal");

		float currentRotationZ = transform.rotation.eulerAngles.z;
		float currentRotationX = transform.rotation.eulerAngles.x;
		float targetAngleZ;
		float targetAngleX;


		if (zRotation < 45 && zRotation > (-45)) {
			targetAngleZ = currentRotationZ + zRotation * Time.deltaTime * turnSpeed;
		} else {
			targetAngleZ = currentRotationZ;
		}

		if (xRotation < 45 && xRotation > (-45)) {
			targetAngleX = currentRotationX + xRotation *Time.deltaTime * turnSpeed;
		} else {
			targetAngleX = currentRotationX;
		}

		//Plane turning motion:
		Quaternion newRotation = Quaternion.Euler (new Vector3 (targetAngleX, 0, targetAngleZ));
		planeRigidbody.MoveRotation (newRotation); 
	}
}
	