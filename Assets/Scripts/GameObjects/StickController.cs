using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DOCS: jump the stick object to any position within a box region. The box region is defined as halfWidth and halfHeight.

public class StickController : MonoBehaviour {
	//internal components
	AudioSource audioSource;

	//gameplay members
	public float halfWidth = 0f;
	public float halfHeight = 0f;

	void Awake() {
		audioSource = GetComponent<AudioSource>();
		RandomizePosition();
	}

	void OnTriggerEnter2D(Collider2D collider) { //notice that triggers use colliders rather than collisions
		ScoreManager.score += 1;
		audioSource.Play();
		RandomizePosition();
	}

	void RandomizePosition() {
		transform.position = new Vector2(Random.Range(-halfWidth, halfWidth), Random.Range(-halfHeight, halfHeight));
	}
}