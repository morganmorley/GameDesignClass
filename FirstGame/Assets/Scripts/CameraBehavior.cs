using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
	//This class dictates the movement of the camera based on the movement of the player.

	public GameObject player; //dragged from the scene
	private Vector3 translationOffset;

	// Use this for initialization
	void Start () {
		translationOffset = transform.position - player.transform.position;
	}
	
	void FixedUpdate () {
		transform.position = player.transform.position + translationOffset;
	}
}
