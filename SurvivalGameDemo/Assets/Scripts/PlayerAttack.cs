using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	LineRenderer bulletLine;
	Ray shootRay;
	float timer;
	public float timeBetweenBullets = 0.15f;
	AudioSource gunSound;

	// Use this for initialization
	void Start () {
		bulletLine = GetComponent<LineRenderer> ();
		bulletLine.enabled = false;
		timer = 0;
		gunSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire") && timer >= timeBetweenBullets) {
			Shoot ();
		}else {
			DisableEffects();
		}
	}

	void DisableEffects () {
		bulletLine.enabled = false;
	}

	void Shoot() {
		timer = 0;

		gunSound.Play ();

		bulletLine.enabled = true;
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		RaycastHit shootHit;
		bulletLine.SetPosition (0, transform.position); //0 = gunbarrel end at transform.position

		if (Physics.Raycast (shootRay, out shootHit)) { //parameters (Ray ray, out RaycastHit hitInfo) returns a boolean
			//enemy takes damage
			bulletLine.SetPosition (1, shootHit.point); //how to hit enemies, 1 = end of ray
		} else {
			bulletLine.SetPosition(1, shootRay.origin + shootRay.direction * 1000); //goes really far if it doesn't hit anything
		}
	}
}
