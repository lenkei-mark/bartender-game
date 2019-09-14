using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    Transform player;
    public SpriteRenderer playerFront;
    public SpriteRenderer playerLeft;
    public SpriteRenderer playerBack;
    public SpriteRenderer playerRight;

	void Start () {
        player = GetComponent<Transform>();
        playerFront.enabled = true;
        playerLeft.enabled = false;
        playerRight.enabled = false;
        playerBack.enabled = false;

	}

	void Update () {
        CheckForInput();
	}

    void CheckForInput()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            playerBack.enabled = false;
            playerFront.enabled = false;
            playerLeft.enabled = false;
            playerRight.enabled = true;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            playerBack.enabled = false;
            playerFront.enabled = false;
            playerLeft.enabled = true;
            playerRight.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            playerFront.enabled = true;
            playerLeft.enabled = false;
            playerBack.enabled = false;
            playerRight.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            playerFront.enabled = false;
            playerLeft.enabled = false;
            playerBack.enabled = true;
            playerRight.enabled = false;
        }
    }
}
