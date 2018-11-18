using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour {

    public GameObject missile;
    float spawnTimer = 1.0f;
    float currentTimer = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentTimer += Time.deltaTime;
        if (currentTimer > spawnTimer)
        {
            Instantiate(missile, gameObject.transform.position, Quaternion.Euler(0, 0, 90));
            currentTimer = 0.0f;
        }
	}
}
