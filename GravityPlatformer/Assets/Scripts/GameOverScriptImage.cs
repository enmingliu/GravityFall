using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScriptImage : MonoBehaviour
{

    public Image im;
    public PlayerController pc1;
    public PlayerController pc2;

    // Use this for initialization
    void Start()
    {
        im.CrossFadeAlpha(0, 0, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pc1.dead || pc2.dead)
        {
            im.CrossFadeAlpha(1, 1f, false);
        }
    }
}
