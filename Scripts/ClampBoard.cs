using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampBoard: MonoBehaviour {

    private Rigidbody2D rigid;
    private Animator anim;

    public GameObject player;
    public float moveSpeed;

    public float minWaitTime = 5;
    public float maxWaitTime = 10;

    public float jumpForce = .5f;

    private bool jumping;
    private bool onGround;

    void Start () {
        anim = GetComponent<Animator>();

        rigid = this.GetComponent<Rigidbody2D>();
        StartCoroutine (JumpTimer());
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    void Update () {
        Move ();
    
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    public void Move() {
        rigid.velocity = new Vector2(moveSpeed, 0);
    }

    IEnumerator JumpTimer() {
        while (true) {
            yield return new WaitForSeconds (Random.Range (5, 10));
            Jump();
            Debug.Log ("Jump");
        }
    }

    public void Jump() {
        rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.GetType() == typeof(CapsuleCollider2D) && col.gameObject.tag == "Wall") {
            moveSpeed *= -1;
            Debug.Log("collided");
        }
        if (col.collider.GetType() == typeof(CapsuleCollider2D) && col.gameObject.tag == "Enemy") {
            moveSpeed *= -1;
        }
        if (col.collider.GetType() == typeof(CapsuleCollider2D) && col.gameObject.tag == "Player") {
            Destroy(col.gameObject);
        }
        if (col.collider.GetType() == typeof(BoxCollider2D) && col.gameObject.tag == "Player") {
            Destroy(col.gameObject);
        }
    }
}