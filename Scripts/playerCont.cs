﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCont : MonoBehaviour {

		public float speed;
		private Rigidbody2D rb;
		public float jump;
		public GameObject rayOrigin;
		public float rayCheckDistance;

	void Start () {
		rb = GetComponent <Rigidbody2D> ();
	}

	void FixedUpdate () {
		float x = Input.GetAxis ("Horizontal");

		if (Input.GetAxis ("Jump") > 0) {
			RaycastHit2D hit = Physics2D.Raycast (rayOrigin.transform.position, Vector2.down, rayCheckDistance);
			if (hit.collider != null) {
				rb.AddForce (Vector2.up * jump, ForceMode2D.Impulse);
			}
		}
		rb.velocity = new Vector2 (x * speed, rb.velocity.y);

		}
	}
