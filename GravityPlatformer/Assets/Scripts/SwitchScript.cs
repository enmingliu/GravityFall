using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

	public bool isFlipped = false;
	public bool lpActive = true;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (lpActive) {
			GameObject.Find("Spikes").transform.localScale = new Vector3(1, 1, 1);
		}
		else {
			GameObject.Find("Spikes").transform.localScale = new Vector3(0, 0, 0);
		}
	}

	private void OnTriggerEnter2D(Collider2D hit) {
		//Debug.Log("flipped");
		if (hit.gameObject.tag == "Player" && !isFlipped) {
			animator.Play("FlipSwitchUp", 0, 0f);
			isFlipped = true;
		}
		else if (hit.gameObject.tag == "Player" && isFlipped) {
			animator.Play("FlipSwitchDown", 0, 0f);
			isFlipped = false;
			if (lpActive) {
				lpActive = false;
			}
			else {
				lpActive = true;
			}
		}
	}
}
