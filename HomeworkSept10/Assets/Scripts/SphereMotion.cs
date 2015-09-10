using UnityEngine;
using System.Collections;

public class SphereMotion : MonoBehaviour {

	public string name;
	Rigidbody physicsbody;


	// Use this for initialization
	void Start () {
		name = "Justin";
		Debug.Log ("Hello " + name);
		physicsbody = GetComponent<Rigidbody> ();
	}
	
	void FixedUpdate () {
		float xMovement = Input.GetAxis("Horizontal");
		float yMovement = Input.GetAxis ("Vertical");
		Debug.Log (xMovement);
		Debug.Log (yMovement);
		physicsbody.velocity = new Vector3(xMovement,yMovement, 0); //movement along x and z axes depending on which button you push

	}
}
