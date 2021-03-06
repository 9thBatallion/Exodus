﻿using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

		public float speed = 6.0F;
		public float jumpSpeed = 8.0F;
		public float gravity = 20.0F;
		private Vector3 moveDirection = Vector3.zero;
		void Update() {
			CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= speed;

			if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
				transform.Translate(Vector3.forward * speed * Time.deltaTime);
			}
			if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
				transform.Translate(Vector3.back * speed * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.Q)){
				transform.Rotate(Vector3.down * speed * 10 * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.E)){
				transform.Rotate(Vector3.down* -speed * 10 * Time.deltaTime);
			}

				if (Input.GetButton("Jump"))
					moveDirection.y = jumpSpeed;
				
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
		}
	}