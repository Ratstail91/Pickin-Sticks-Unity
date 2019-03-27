using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DOCS: this input system ensures that the character only moves once per second, in a grid-like pattern

public class PlayerController : MonoBehaviour {
	//constants
	enum Direction {
		UP = 0,
		RIGHT = 1,
		DOWN = 2,
		LEFT = 3
	};

	const float deadZone = 0.25f; //for joysticks
	const float distance = 1f; //distance to move each step

	//internal components
	Animator animator;
	Rigidbody2D rigidBody;

	//input
	float horizontalInput = 0f;
	float verticalInput = 0f;

	//animation
	Direction direction = Direction.DOWN;

	void Awake() {
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		HandleInput();
		HandleMovement();
		HandleAnimation();
	}

	void HandleInput() {
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
	}

	void HandleMovement() {
		Vector2 position = rigidBody.position;

		if (verticalInput < 0) {
			//if moving down
			direction = Direction.DOWN;
			position.y -= distance * Time.deltaTime;
		} else if (verticalInput > 0) {
			//if moving up
			direction = Direction.UP;
			position.y += distance * Time.deltaTime;
		} else if (horizontalInput < 0) {
			//if moving left
			direction = Direction.LEFT;
			position.x -= distance * Time.deltaTime;
		} else if (horizontalInput > 0) {
			//if moving right
			direction = Direction.RIGHT;
			position.x += distance * Time.deltaTime;
		}

		//set the new position
		rigidBody.position = position;
	}

	void HandleAnimation() {
		//separate animation signals
		animator.SetBool("Moving", !(horizontalInput == 0 && verticalInput == 0));
		animator.SetInteger("Direction", (int)direction); //be sure to convert the enum to int
	}
}
