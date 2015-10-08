using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 30;

	int currentHealth;

	void Start () {
		currentHealth = maxHealth;
	}

	public void TakeDamage (int damage) {
		currentHealth = currentHealth - damage;
		if (currentHealth <= 0) {
			//stop moving
			//death animation
		}
	}
}
