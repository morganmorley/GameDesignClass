using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlaneBehavior : MonoBehaviour {

	Rigidbody planeRigidbody;
	public float movementSpeed = 6f; //= 6.0
	public float turnSpeed = 65f;
	public Text youWin; //the notification of successfully eating 4 boxes


	// Use this for initialization
	void Start () {
		planeRigidbody = GetComponent <Rigidbody> ();
		youWin.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		float zRotation = Input.GetAxis ("Vertical");
		float xRotation = Input.GetAxis ("Horizontal");

		float currentRotationZ = transform.rotation.eulerAngles.z;
		float currentRotationX = transform.rotation.eulerAngles.x;
		float targetAngleZ = currentRotationZ + zRotation * Time.deltaTime * turnSpeed;
		float targetAngleX = currentRotationX + xRotation * Time.deltaTime * turnSpeed;


		if (targetAngleZ >= 60) {
			targetAngleZ = 60;
		} else if (targetAngleZ <= -60) {
			targetAngleZ = -60;
		} else if (targetAngleX >= 60) {
			targetAngleX = 60;
		} else if (targetAngleX <= -60) {
			targetAngleX = -60;
		}

		//Plane turning motion:
		Quaternion newRotation = Quaternion.Euler (new Vector3 (targetAngleX, 0, targetAngleZ));
		planeRigidbody.MoveRotation (newRotation); 


	}

	void OnTriggerEnter(Collider cube){
		//when roll through a box, it "triggers" this function
		cube.gameObject.SetActive (false); //this sets cube inactive and it disappears
		youWin.gameObject.SetActive(true);
	}
}
	