using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour {

    public Text text;
    private float startTime= 280.0f;
	// Use this for initialization
    void Start () {
        text.text = "Time: " + startTime;

	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Time: " + (int)(startTime - Time.fixedTime);
    }
}
