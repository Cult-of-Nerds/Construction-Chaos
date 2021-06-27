using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    private PlayerController playerControllerScript;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver)
        {
            text.text = "Press 'r' to restart";
        }
    }
}
