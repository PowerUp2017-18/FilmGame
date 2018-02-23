using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelMeanie : MonoBehaviour {

    private Rigidbody2D rigid;
    private Animator anim;

    public GameObject player;
    public float moveSpeed;

    void Start () {
        anim = GetComponent<Animator>();

        rigid = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    void Update () {
        Move ();
    
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(1, 1, 1);
    }

    public void Move() {
        rigid.velocity = new Vector2(moveSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Wall") {
            moveSpeed *= -1;
        }
        if (col.gameObject.tag == "Enemy") {
            moveSpeed *= -1;
        }
        if(col.gameObject.tag == "Player") {
            Destroy(col.gameObject);
        }
    }
}