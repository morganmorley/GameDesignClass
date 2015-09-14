using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	public GameObject player;
	Vector3 translationOffset;

	// Use this for initialization
	void Start () {
		translationOffset = transform.position - player.transform.position;

	}
	
	void FixedUpdate () {
		transform.position = player.transform.position + translationOffset;
	}
}
