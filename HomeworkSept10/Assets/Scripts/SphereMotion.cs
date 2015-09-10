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
	
	void FixedUpdate () {
		float xMovement = Input.GetAxis("Horizontal");
		float yMovement = Input.GetAxis ("Vertical");
		Debug.Log (xMovement);
		Debug.Log (yMovement);
		physicsbody.AddForce(new Vector3(xMovement,yMovement, 0) * speed); 
	}
}
