using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour {

    public float movespeed = 5f;
    private Vector2 movement=Vector2.zero;
    private Rigidbody2D rb;

    public Sprite rightSprite;
    public Sprite leftSprite;
    public Sprite upSprite;
    public Sprite downSprite;
    public SpriteRenderer sr;

    public BoxCollider2D rightCol;
    public BoxCollider2D leftCol;
    public BoxCollider2D upCol;
    public BoxCollider2D downCol;

    public BoxCollider2D upTri;
    public BoxCollider2D leftTri;
    public BoxCollider2D rightTri;
    public BoxCollider2D downTri;

    public bool hasWater;
    public bool hasBeer;
    public SpriteRenderer waterPopUp;
    public SpriteRenderer beerPopUp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        HasDrink();
	}

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);

        if(movement.y>0.1f)
        {
            sr.sprite = upSprite;
            upCol.enabled = true;
            downCol.enabled = false;
            rightCol.enabled = false;
            leftCol.enabled = false;
            upTri.enabled = true;
            downTri.enabled = false;
            leftTri.enabled = false;
            rightTri.enabled = false;
        }
        else if(movement.y<-0.1f)
        {
            sr.sprite = downSprite;
            upCol.enabled = false;
            downCol.enabled = true;
            rightCol.enabled = false;
            leftCol.enabled = false;
            upTri.enabled = false;
            downTri.enabled = true;
            leftTri.enabled = false;
            rightTri.enabled = false;
        }
        
        if(movement.x>0.1f)
        {
            sr.sprite = rightSprite;
            upCol.enabled = false;
            downCol.enabled = false;
            rightCol.enabled = true;
            leftCol.enabled = false;
            upTri.enabled = false;
            downTri.enabled = false;
            leftTri.enabled = false;
            rightTri.enabled = true;
        }
        else if(movement.x<-0.1f)
        {
            sr.sprite = leftSprite;
            upCol.enabled = false;
            downCol.enabled = false;
            rightCol.enabled = false;
            leftCol.enabled = true;
            upTri.enabled = false;
            downTri.enabled = false;
            leftTri.enabled = true;
            rightTri.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("WaterChest"))
        {
            hasWater = true;
            hasBeer = false;
        }

        if(other.CompareTag("BeerChest"))
        {
            hasBeer = true;
            hasWater = false;
        }

        if(other.tag=="Customer")
        {
            Invoke("CancelDrink", 0.1f);
        }
    }

    void CancelDrink()
    {
        hasWater = false;
        hasBeer = false;
    }

    void HasDrink()
    {
        if (hasWater)
        {
            waterPopUp.enabled = true;
            beerPopUp.enabled = false;
        }
        else if(hasBeer)
        {
            beerPopUp.enabled = true;
            waterPopUp.enabled = false;
        }
        else
        {
            beerPopUp.enabled = false;
            waterPopUp.enabled = false;
        }
    }
}
