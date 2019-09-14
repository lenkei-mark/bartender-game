using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindChair : MonoBehaviour {

    public GameObject[] chairs;
    public int choose;
    public isReserved[] reserved;
    public bool takenSeat;

    public float speed;
	void Start ()
    {
        chairs = GameObject.FindGameObjectsWithTag("Chair");
        choose = Mathf.RoundToInt(Random.Range(0, chairs.Length));
        for (int i = 0; i < reserved.Length; i++)
        {
            reserved[i] = chairs[i].GetComponent<isReserved>();
        }
        
    }
	

	void Update ()
    {
        Movement();
	}

    void Movement()
    {
        if(takenSeat==false)
        {
            if (reserved[choose].reserved)
            {
                choose = Mathf.RoundToInt(Random.Range(0, chairs.Length));
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Chair")
        {
            takenSeat = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Chair")
        {
            takenSeat = false;
        }
    }
}
