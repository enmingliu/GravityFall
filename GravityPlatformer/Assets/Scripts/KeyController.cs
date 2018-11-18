using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

    private bool collected = false;
    private Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (collected && Input.GetKey("space")) {
            collected = !collected;
            this.transform.position = new Vector3(player.position.x, player.position.y, -5);
        }
        if (collected) {
            this.transform.position = player.position;
            this.transform.rotation = player.rotation;
        }
	}

    void OnTriggerStay2D(Collider2D hit)
    {
        if (!collected && hit.gameObject.tag == "Player" && Input.GetKey("space")) {
            collected = true;
            player = hit.gameObject.transform;
        }
    }
}
