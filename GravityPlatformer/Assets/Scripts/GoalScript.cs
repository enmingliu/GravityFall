using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GoalScript : MonoBehaviour {

    public bool opened = false;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<PlayerController>().keyCarried)
        {
            animator.Play("OpenChest");
            opened = true;
            Destroy(GameObject.FindGameObjectWithTag("Key"));
        }
    }
}
