using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAI : MonoBehaviour
{

    public Sprite happy;
    public Sprite sad;
    public Sprite back;
    public SpriteRenderer sr;
    public SpriteRenderer waterPopUp;
    public SpriteRenderer beerPopUp;

    public bool inContact;
    public bool gotWater;
    public bool gotBeer;
    public bool gaveMoney = false;
    Test1 water;
    GameObject exit;

    public GameObject[] chairs;
    public int choose;
    public isReserved[] reserved;
    public bool takenSeat;
    public int drinkChoice;
    Money money;

    public float speed;
    public bool going;
    float time;
    public float waitTime = 10f;

    public int howManyReserved = 0;
    private bool hasDoneCheck = false;


    void Start()
    {
        water = GameObject.FindGameObjectWithTag("Player").GetComponent<Test1>();
        exit = GameObject.FindGameObjectWithTag("Exit");
        chairs = GameObject.FindGameObjectsWithTag("Chair");
        for (int i = 0; i < reserved.Length; i++)
        {
            reserved[i] = chairs[i].GetComponent<isReserved>();
        }
        money = GameObject.FindGameObjectWithTag("Counter").GetComponent<Money>();
        choose = Mathf.RoundToInt(Random.Range(0, chairs.Length));
        drinkChoice = Mathf.RoundToInt(Random.Range(0f, 1f));

    }

    void FixedUpdate()
    {
        Movement();
        SpriteManager();
        ChooseDrink();
        waitTime -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inContact = true;
        }

        if (other.tag == "Chair")
        {
            takenSeat = true;
        }

        if (other.CompareTag("Exit"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inContact = false;
        }
        if (other.tag == "Chair")
        {
            takenSeat = false;
        }
    }

    void Movement()
    {
        if (going == false && waitTime > 0f)
        {
            if (takenSeat == false)
            {
                if (reserved[choose].reserved)
                {
                    choose = Mathf.RoundToInt(Random.Range(0, chairs.Length));
                }
                else if (!CheckForRightPlace()&&!hasDoneCheck)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(chairs[choose].transform.position.x, 2.55f), speed * Time.deltaTime);
                    if(CheckForRightPlace())
                    {
                        hasDoneCheck = true;
                    }
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, chairs[choose].transform.position, speed * Time.deltaTime);
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, chairs[choose].transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, exit.transform.position, speed * Time.deltaTime);
            sr.sprite = back;
            MoneyIncrease(-5);
        }


    }

    void SpriteManager()
    {
        if (inContact && water.hasWater && drinkChoice == 0)
        {
            gotWater = true;
        }
        if (inContact && water.hasBeer && drinkChoice == 1)
        {
            gotBeer = true;
        }

        if (gotWater)
        {
            if (going == false)
            {
                sr.sprite = happy;
            }
            MoneyIncrease(10);
            waitTime = 60f;
            time = Random.Range(10f, 20f);
            Invoke("GoingTrue", time);
        }
        else if (gotBeer)
        {
            if (going == false)
            {
                sr.sprite = happy;
            }
            MoneyIncrease(20);
            waitTime = 60f;
            time = Random.Range(10f, 20f);
            Invoke("GoingTrue", time);
        }
        else
        {
            sr.sprite = sad;
        }

    }

    void GoingTrue()
    {
        going = true;
    }

    void ChooseDrink()
    {
        if (drinkChoice == 0)
        {
            if (takenSeat && gotWater == false)
            {
                waterPopUp.enabled = true;
            }
            else if (gotWater)
            {
                waterPopUp.enabled = false;
            }
        }

        if (drinkChoice == 1)
        {
            if (takenSeat && gotBeer == false)
            {
                beerPopUp.enabled = true;
            }
            else if (gotBeer)
            {
                beerPopUp.enabled = false;
            }
        }

    }

    void MoveRandomly()
    {
        float moveX = Random.Range(-5f, 5f);
        float moveY = Random.Range(2.5f, 4f);
        Vector2 MoveTo = new Vector2(moveX, moveY);
        transform.position = Vector2.MoveTowards(transform.position, MoveTo, speed * Time.deltaTime);
    }

    void MoneyIncrease(int amount)
    {
        if (gaveMoney == false)
        {
            money.money += amount;
            gaveMoney = true;
        }
    }

    bool CheckForRightPlace()
    {
        if(transform.position==new Vector3(chairs[choose].transform.position.x, 2.55f, 0f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
