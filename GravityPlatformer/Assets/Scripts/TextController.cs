using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour {

    public string sceneName = "Level One";

    private Text m_text;
    private GameObject chest;
    public PlayerController pc1;
    public PlayerController pc2;

	// Use this for initialization
    void Start () {
        //pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        m_text = GetComponent<Text>();
        chest = GameObject.FindGameObjectWithTag("Chest");
	}

    void changeText(string text)
    {
        m_text.text = text;
    }

    // Update is called once per frame
    void Update () {
        if (chest.GetComponent<GoalScript>().opened)
        {
            changeText("LEVEL CLEARED!");
            Destroy(GameObject.FindGameObjectWithTag("Key"));
            Invoke("LoadScene", 3f);
        }
	}

    void LoadScene() {
        SceneManager.LoadScene(sceneName);
        pc1.dead = false;
        pc2.dead = false;
    }
}
