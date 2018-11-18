using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RemoveComponent : MonoBehaviour {

    public Text text;
    float timer = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 2.0f)
        {
            text.text = "";
        }
		
	}
}
