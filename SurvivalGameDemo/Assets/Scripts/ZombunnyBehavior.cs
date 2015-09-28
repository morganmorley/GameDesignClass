using UnityEngine;
using System.Collections;

public class ZombunnyBehavior : MonoBehaviour {

	public float bunnySpeed = 3f;
	public float turnSpeed = 40f;
	public GameObject player;
	Animator zombunnyAnimator;
	Rigidbody zombunnyBody;


		// Use this for initialization;
	void Start () {
		zombunnyAnimator = GetComponent <Animator> ();
		zombunnyBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		//moving
		Vector3 distanceToPlayer = player.transform.position - transform.position;
		Vector3 movement = distanceToPlayer.normalized * Time.deltaTime * bunnySpeed;
		zombunnyBody.MovePosition (transform.position + movement);

		//turning
		float currentRotation = transform.rotation.eulerAngles.y;
		float turnMovement = player.transform.rotation.eulerAngles.y - currentRotation;
		float targetAngle = currentRotation + turnMovement * Time.deltaTime * turnSpeed;
		Quaternion newRotation = Quaternion.Euler (new Vector3 (0, targetAngle, 0));
		zombunnyBody.MoveRotation (newRotation);
	}
}
