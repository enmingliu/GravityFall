using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

	private float useSpeedY;
	private float useSpeedX;

	public float directionSpeedY = 9.0f;
	public float directionSpeedX = 9.0f;
	float origY;
	float origX;
	public float distanceX = 10.0f;
	public float distanceY = 10.0f;

	// Use this for initialization
	void Start () {

		origY = transform.position.y;
		origX = transform.position.x;
		useSpeedY = -directionSpeedY;
		useSpeedX = -directionSpeedX;
		
	}
	
	// Update is called once per frame
	void Update () {

		if(origY - transform.position.y > distanceY) {
            useSpeedY = directionSpeedY; //flip direction
        }
        else if(origY - transform.position.y < -distanceY) {
            useSpeedY = -directionSpeedY; //flip direction
        }
        transform.Translate(0, useSpeedY * Time.deltaTime, 0);
		
        if(origX - transform.position.x > distanceX) {
            useSpeedX = directionSpeedX; //flip direction
        }
        else if(origX - transform.position.x < -distanceX) {
            useSpeedX = -directionSpeedX; //flip direction
        }
        transform.Translate(useSpeedX * Time.deltaTime, 0, 0);

	}
}
