﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidbody;

	public float jumpSpeed;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	public bool isGrounded; 

	private Vector3 spawnLocation;
 


	public Animator animator;

	void Start() {
		myRigidbody = GetComponent<Rigidbody2D>();
		spawnLocation=transform.position;
	}

	void Update() {
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if (Input.GetAxisRaw("Horizontal") > 0f) {
			myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
			transform.localScale = new Vector3(4f, 4f, 1f);
			animator.SetFloat("Speed",moveSpeed);
			} else if (Input.GetAxisRaw("Horizontal") < 0f) {
				myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
				transform.localScale = new Vector3(-4f, 4f, 1f);

			animator.SetFloat("Speed",moveSpeed);
			} else {
				myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);

			animator.SetFloat("Speed",0f);
			}

			if (Input.GetButtonDown("Jump") && isGrounded) {
				myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
			}
		}


		public void Kill(){
			transform.position=spawnLocation;
		}



		void OnTriggerEnter2D(Collider2D col)
		{
			if(col.gameObject.CompareTag("Checkpoint"))
			{
				spawnLocation=col.transform.position+new Vector3(0.2f,0,0);
			}
		}



}
