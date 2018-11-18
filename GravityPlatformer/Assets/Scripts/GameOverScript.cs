using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public Text text;
    public PlayerController pc1;
    public PlayerController pc2;

	// Use this for initialization
	void Start () {
        text.CrossFadeAlpha(0, 0f, false);
    }
	
	// Update is called once per frame
	void Update () { 
        if(pc1.dead || pc2.dead)
        {
            text.CrossFadeAlpha(1, 1f, false);
        }
	}
}
