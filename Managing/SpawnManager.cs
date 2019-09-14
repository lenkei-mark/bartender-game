using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] customers;
    public GameObject spawnPoint;
    public DayTime decor;
    public float spawnTime = 2f;
    private int chooseCust;
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Spawn()
    {
        if(decor.decor<50)
        {
            chooseCust = 0;
        }
        else if(decor.decor>=50 && decor.decor<100)
        {
            chooseCust = Random.Range(0, 2);
        }
        else if(decor.decor>=100)
        {
            chooseCust = Random.Range(1, 3);
        }

        Instantiate(customers[chooseCust], transform.position, transform.rotation);
    }
}
