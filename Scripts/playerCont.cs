using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCont : MonoBehaviour {

		public float speed;
		private bool onGround = false;
		public float jumpForce;

		private Rigidbody2D rb;
		private Vector2 jumping;

	void Start () {
		rb = GetComponent <Rigidbody2D> ();
	}

	void FixedUpdate () {
		Jump();
	}

	public void Jump() {
		if (onGround && Input.GetKeyDown(KeyCode.Space)) {
       		rb.AddForce(new Vector2(0, jumpForce));
    	} 

    	if(Input.GetKeyDown(KeyCode.A)) {
    		rb.velocity = new Vector2(-speed, 0);
    	} else if(Input.GetKeyDown(KeyCode.D)) {
    		rb.velocity = new Vector2(speed, 0);
    	}

	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Ground") {
			onGround = true;
		} else {
			onGround = false;
		}
	}
}
