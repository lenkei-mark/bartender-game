using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isReserved : MonoBehaviour {

    public bool reserved;

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag=="Customer")
        {
            reserved = true;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if(other.tag=="Customer")
        {
            reserved = false;
        }
    }
}
