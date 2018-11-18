using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour {

    private GameObject target;
    public float rotationSpeed = 1.0f;
    public float angleChangingSpeed;
    public float movementSpeed;
    Rigidbody2D rb;
    public PlayerController pc;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = ((Vector2)target.transform.position + new Vector2(0f, 0.5f)) - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -angleChangingSpeed * rotateAmount;
        rb.velocity = transform.up * movementSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == pc.gameObject){
            Destroy(this.gameObject);
            pc.dead = true;
        }
            
    }
}
