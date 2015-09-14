using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	//defines the movement of the player sphere

	Rigidbody physicsbody;
	public int speed; //mult to vector to increase speed
	public Text scoreboard;
	public Text youWin;
	int count; //for scoreboard

	// Use this for initialization
	void Start () {
		physicsbody = GetComponent<Rigidbody> ();
		speed = 3;
		count = 0;
		UpdateScore (count);
		youWin.gameObject.SetActive (false);
	}
	
	void FixedUpdate () {
		float xMovement = Input.GetAxis("Horizontal");
		float zMovement = Input.GetAxis ("Vertical");
		physicsbody.AddForce(new Vector3(xMovement,0,zMovement) * speed); //movement along x and z axes depending on which button you push
	}

	void OnTriggerEnter(Collider cube){
		//when roll through a box, it "triggers" this function
		cube.gameObject.SetActive (false); //this sets cube inactive and it disappears
		count++;
		UpdateScore (count);
	}

	void UpdateScore (int newScore) {
		string score = "Score: " + newScore.ToString ();
		scoreboard.text = score;
		if (count > 3) {
			youWin.gameObject.SetActive(true);
		}
	}
}
