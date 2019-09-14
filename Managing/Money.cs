using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    public int money;
    public Text counter;

    void Start()
    {
        counter.text = "0";
    }
	void Update () {
        counter.text = money.ToString();
        CheckInput();
	}

    void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            money += 1000;
        }
    }
}
