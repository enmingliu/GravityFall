using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator ani;
    private GameObject player;

    private float distance;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ani = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        ani.SetBool("IsMoving", false);
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if( distance <= 8)
        {
            if (player.transform.position.x > gameObject.transform.position.x)
            {
                gameObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
                rb.velocity = Vector2.right;
                ani.SetBool("IsMoving", true);
            } else if (player.transform.position.x < gameObject.transform.position.x)
            {
                gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                rb.velocity = Vector2.left;
                ani.SetBool("IsMoving", true);
            } else 
            {
                ani.SetBool("IsMoving", false);
            }
        }
	}
}
