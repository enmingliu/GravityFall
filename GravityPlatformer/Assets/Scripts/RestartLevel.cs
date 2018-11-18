using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {

    public Button bb;
	// Use this for initialization
	void Start () {
        bb.onClick.AddListener(TaskOnClick);

	}
	
	// Update is called once per frame
    void TaskOnClick(){
        SceneManager.LoadScene("Level One");
    }
}
