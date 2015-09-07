using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//defines the movement of the player sphere

	Rigidbody physicsbody;
	int speed; //mult to vector to increase speed
	int score; //for scoreboard

	// Use this for initialization
	void Start () {
		physicsbody = GetComponent<Rigidbody> ();
		speed = 3;
		score = 0;
	}
	
	void FixedUpdate () {
		float xMovement = Input.GetAxis("Horizontal");
		float zMovement = Input.GetAxis ("Vertical");
		physicsbody.AddForce(new Vector3(xMovement,0,zMovement) * speed); //movement along x and z axes depending on which button you push
	}

	void OnTriggerEnter(Collider cube){
		//when roll through a box, it "triggers" this function
		cube.gameObject.SetActive (false); //this sets cube inactive and it disappears
		score = score + 1;
	}
}
