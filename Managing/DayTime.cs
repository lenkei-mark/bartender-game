using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTime : MonoBehaviour {

    public float timeHour;
    public float timeMinute;
    public Text clock;
    public Money money;
    public SpriteRenderer background;
    public Sprite basicFloor;
    public Sprite upgradedFloor;

    public GameObject shop;

    public GameObject[] chairs;
    public SpriteRenderer[] chairsSr;
    public Sprite basicChair;
    public Sprite upgradedChair;

    public SpriteRenderer barpult;
    public Sprite basicBarpult;
    public Sprite upgradedBarPult;

    public int decor=0;

	void Start ()
    {
        shop.SetActive(false);
        money = GameObject.FindGameObjectWithTag("Counter").GetComponent<Money>();
        chairs = GameObject.FindGameObjectsWithTag("Chair");
        for (int i = 0; i < chairs.Length; i++)
        {
            chairsSr[i] = chairs[i].GetComponent<SpriteRenderer>();
        }
    }
	
	void Update ()
    {
        timeMinute += Time.deltaTime*20;

        if(timeMinute>=60)
        {
            timeMinute = 0;
            timeHour++;
        }

        if(timeHour>=24)
        {
            timeHour = 0;
            Time.timeScale = 0.00001f;
            shop.SetActive(true);
        }

        clock.text = timeHour.ToString() + ":" + timeMinute.ToString("0");
        ChangeTime();
	}
    public void Continue()
    {
        Time.timeScale = 1f;
        shop.SetActive(false);
    }
    private bool upgradedFloorbool = false;
    public void UpgradeFloor()
    {
        if (money.money>=500 && !upgradedFloorbool)
        {
            money.money -= 500;
            background.sprite = upgradedFloor;
            decor += 50;
            upgradedFloorbool = true;
        }
    }
    private int chairNumber;
    public void UpgradeChair()
    {

        if(money.money>=100 && chairNumber<7)
        {
            money.money -= 100;
            chairsSr[chairNumber].sprite = upgradedChair;
            decor += 10;
            chairs[chairNumber].transform.localScale -= new Vector3(0.75f, 0.75f, 0);
            chairNumber++;
        }
        
    }
    private bool upgradedBarpultbool = false;
    public void UpgradeBarpult()
    {
        if(money.money>=250 && !upgradedBarpultbool)
        {
            money.money -= 250;
            barpult.sprite = upgradedBarPult;
            decor += 25;
            upgradedBarpultbool = true;

        }
    }

    void ChangeTime()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            timeHour = 23;
        }
    }
}
