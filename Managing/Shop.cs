using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public GameObject shop;
    public DayTime time;

	void Start () {
        shop.SetActive(false);
    }
	

	void Update () {
		if(time.timeHour>=24 && Time.timeScale==1f)
        {
            Time.timeScale = 0.00001f;
            shop.SetActive(true);
        }
	}

    public void Continue()
    {
        Time.timeScale = 1f;
        shop.SetActive(false);
    }
}
