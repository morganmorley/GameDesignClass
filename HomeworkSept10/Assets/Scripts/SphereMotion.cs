using UnityEngine;
using System.Collections;

public class SphereMotion : MonoBehaviour {

	public string name;
	Rigidbody physicsbody;
	public int speed;


	// Use this for initialization
	void Start () {
		name = "Justin";
		Debug.Log ("Hello " + name);
		physicsbody = GetComponent<Rigidbody> ();
		speed = 1;

	}
	
	void Update () {
		//float xMovement = Input.GetAxis("Horizontal");
		//float yMovement = Input.GetAxis ("Vertical");
		//Debug.Log (xMovement);
		//Debug.Log (yMovement);
		Vector3 movementVector = new Vector3(1, 0, 0);
		movementVector = movementVector.normalized * speed * Time.deltaTime;
		physicsbody.MovePosition(transform.position + movementVector);	}
}
