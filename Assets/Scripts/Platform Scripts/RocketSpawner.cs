using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public GameObject rocketPrefab;
    public float min_Y = -5f, max_Y = 5f;//spawnamo rakete između ovih granica
    //public float bound_Y1 = -5.5f; //kada asteroid izađe sa ekrana

 
    void Start()
    {
        InvokeRepeating("SpawnRockets", 0.5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void SpawnRockets()
    {
        //kontroliramo spawnanje
        Vector3 temp = transform.position;
        temp.y = Random.Range(min_Y, max_Y);  //da se spawna između X-eva

        GameObject newPlatform = null;
        newPlatform = Instantiate(rocketPrefab, temp, Quaternion.identity);

        if (newPlatform)//ovo je jednako
            newPlatform.transform.parent = transform;
    }
}