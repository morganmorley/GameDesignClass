using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	//defines the movement of the player sphere

	private Rigidbody physicsbody; //a component of the player that allows it to interact with physics properties
	public int speed; //multiplies to vector to regulate speed
	public Text scoreboard; //scoreboard shown onscreen
	public Text youWin; //the notification of successfully eating 4 boxes
	public int count; //the scoreboard's integer score

	void Start () {
		physicsbody = GetComponent<Rigidbody> ();
		speed = 3;
		count = 0;
		UpdateScore (count);
		youWin.gameObject.SetActive (false);
	}
	
	void FixedUpdate () {
		float xMovement = Input.GetAxis("Horizontal"); //links to horizontal arrow keys
		float zMovement = Input.GetAxis ("Vertical"); //links to vertical arrow keys
		physicsbody.AddForce(new Vector3(xMovement,0,zMovement) * speed); //movement along x and z axes depending on which button you push
	}

	void OnTriggerEnter(Collider cube){
		//when roll through a box, it "triggers" this function
		cube.gameObject.SetActive (false); //this sets cube inactive and it disappears
		count++; //score increases
		UpdateScore (count);
	}

	void UpdateScore (int newScore) {
		//changes the scoreboard and notifies player if they win
		string score = "Score: " + newScore.ToString ();
		scoreboard.text = score;
		if (count > 3) {
			youWin.gameObject.SetActive(true);
		}
	}
}
