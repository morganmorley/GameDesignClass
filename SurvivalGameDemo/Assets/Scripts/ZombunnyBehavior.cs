using UnityEngine;
using System.Collections;

public class ZombunnyBehavior : MonoBehaviour {

	public float bunnySpeed = 3f;
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
		zombunnyAnimator.SetBool("IsWalking", true);

		//toward player
		Vector3 distanceToPlayer = player.transform.position - transform.position;
		Vector3 movement = distanceToPlayer.normalized * Time.deltaTime * bunnySpeed;

		//turning
		Quaternion newRotation = Quaternion.LookRotation(movement);

		//moving
		zombunnyBody.MovePosition (transform.position + movement);
		zombunnyBody.MoveRotation (newRotation);
	}
}
