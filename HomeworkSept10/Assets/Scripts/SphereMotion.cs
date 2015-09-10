using UnityEngine;
using System.Collections;

public class SphereMotion : MonoBehaviour {

	public string name;

	// Use this for initialization
	void Start () {
		name = "Justin";
		Debug.Log ("Hello " + name);
	}
	
	void FixedUpdate () {
		float xMovement = Input.GetAxis("Horizontal");
		float yMovement = Input.GetAxis ("Vertical");
		Debug.Log (xMovement);
		Debug.Log (yMovement);
	}
}
