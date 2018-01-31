uusing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCont : MonoBehaviour {

		public float speed;
		public bool onGround;
		public float jumpForce;

		private Rigidbody2D rb;
		private Vector2 jumping;

	void Start () {
		rb = GetComponent <Rigidbody2D> ();
	}

	void FixedUpdate () {
		Jump();
		Move();
	}

	public void Jump() {
		if (onGround && Input.GetKeyDown(KeyCode.Space)) {
       		rb.velocity = new Vector2(this.rb.velocity.x, jumpForce);
       		onGround = false;
    	} 
	}

	public void Move() {
    	if(Input.GetKey(KeyCode.A)) {
    		rb.velocity = new Vector2(-speed, this.rb.velocity.y);
    	} else if(Input.GetKey(KeyCode.D)) {
    		rb.velocity = new Vector2(speed, this.rb.velocity.y);
    	}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Ground") {
			onGround = true;
		}
	}
}
