using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [HideInInspector] public bool jump = true;

    public bool dead = false;
    public bool direction = true; //True indicates up-down, false indicates left-right
    public bool keyCarried = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 25f;
    public Transform groundCheck;
    private SpriteRenderer sr;

    private bool grounded = false;
    private bool grav = false;
    private Rigidbody2D rb2d;
    private Animator animator;
    private ConstantForce2D sideGrav;
    public PlayerController pc;

    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
        if (!direction) sideGrav = GetComponent<ConstantForce2D>();

    }

    // Detect collision with floor
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Ground" || hit.gameObject.tag == "Platform")
        {
            grounded = true;
        }
    }

    // Detect collision exit with floor
    void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Ground" || hit.gameObject.tag == "Platform")
        {
            grounded = false;
        }
    }

    // Detect continued collision with floor
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            keyCarried = true;
        }
        if (collision.gameObject.tag == "Spikes") {
        	dead = true;
        	animator.Play("Dying");
        }

        if (collision.gameObject.tag == "Platform") {
        	pc.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key") {
            keyCarried = false;
        }
        pc.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (direction && Input.GetButtonDown("Jump") && grounded && !dead)
        { //if on ground and jump is pressed, set jump to true
            jump = true;
        }
        else if (!direction && Input.GetButtonDown("Jump2") && grounded && !dead)
        {
            jump = true;
        }

        if (Input.GetButtonDown("Fire1") && grounded && !dead)
        {
            grav = !grav;
        }

        if (direction) animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); //Sets speed variable to determine what animation is played
        else animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.y));

        if (direction && rb2d.velocity.x > 0.1) sr.flipX = false; //Face right
        else if (direction && rb2d.velocity.x < -0.1) sr.flipX = true; //Face left
        else if (!direction && rb2d.velocity.y > 0.1) sr.flipX = false; //Face up
        else if (!direction && rb2d.velocity.y < -0.1) sr.flipX = true; //Face down
    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (direction && h * rb2d.velocity.x < maxSpeed && !dead)
        { //are we under speed limit
            rb2d.AddForce(Vector2.right * h * moveForce); //add force 
        }
        else if (!direction && v * rb2d.velocity.y < maxSpeed && !dead)
        {
            rb2d.AddForce(Vector2.up * v * moveForce);
        }

        if (direction && Mathf.Abs(rb2d.velocity.x) > maxSpeed && !dead)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y); //returns 1 if positive, -1 if negative number, set that direction of maxSpeed
        }
        else if (!direction && Mathf.Abs(rb2d.velocity.y) > maxSpeed && !dead)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Sign(rb2d.velocity.y) * maxSpeed); //returns 1 if positive, -1 if negative number, set that direction of maxSpeed
        }

        if (direction && jump && grav && !dead)
        {
            rb2d.AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse); //0 x, jumpForce y
            jump = false;
        }
        else if (direction && jump && !grav && !dead)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); //0 x, jumpForce y
            jump = false;
        }
        if (!direction && jump && grav && !dead)
        {
            rb2d.AddForce(new Vector2(jumpForce, 0f), ForceMode2D.Impulse);
            jump = false;
        }
        else if (!direction && jump && !grav && !dead)
        {
            rb2d.AddForce(new Vector2(-jumpForce, 0f), ForceMode2D.Impulse);
            jump = false;
        }

        if (direction && grav)
        {
            Physics2D.gravity = new Vector2(0f, 9.8f);
            sr.flipY = true; //Turn upside down
        }
        else if (direction)
        {
            Physics2D.gravity = new Vector2(0f, -9.8f);
            sr.flipY = false; //Normal gravity/upright
        }
        else if (!direction && grav)
        {
            sideGrav.force = new Vector2(-9.8f * rb2d.mass, 0f);
            sr.flipY = true;
        }
        else
        {
            sideGrav.force = new Vector2(9.8f * rb2d.mass, 0f);
            sr.flipY = false;
        }

    }
}
