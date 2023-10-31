using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; //asteroid

    public float platform_Spawn_Timer1 = 1.8f;//svake 1.8 sekunde
    private float current_Platform_Spawn_Timer1;
    public float bound_Y1 = -5.5f; //kada asteroid izađe sa ekrana

    private int platform_Spawn_Count;
    public float min_X = -7f, max_X = 7f;  //spawnamo platgorme između ovih granica
    void Start()
    {
        current_Platform_Spawn_Timer1 = platform_Spawn_Timer1;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();  //počni stvarat platforme
        DestroyAsteroid();
    }

    void SpawnPlatforms()
    {
        current_Platform_Spawn_Timer1 += Time.deltaTime;
        //svaki frame na current_Platform_Spawn_Timer dodajemo Time.deltaTime u update metodi
        //i kada current postane veci od platform_Spawn_Timer izvodi se if uvjet

        if (current_Platform_Spawn_Timer1 >= platform_Spawn_Timer1)
        {
            platform_Spawn_Count++;  //kontroliramo spawnanje
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);  //da se spawna između X-eva

            GameObject newPlatform = null;
            if (platform_Spawn_Count < 2)  //dok je count manje od nule stvaramo obicnu platformu
            {
                newPlatform = Instantiate(asteroidPrefab, temp, Quaternion.identity);
                platform_Spawn_Count = 0;
            }
            
            

            //newPlatform.transform.parent = transform;  //kako bi svaka platforma bila dijete od Platform spawnera da nam ne bude neuredna hijerarhija
            if (newPlatform)//ovo je jednako
                newPlatform.transform.parent = transform;
            current_Platform_Spawn_Timer1 = 0f;//resetiramo timer da svaki put se vrati na nulu, čeka koliko treba i stvori opet
        }//stvara platformu
    }

    void DestroyAsteroid()
    {
        Vector2 tempA = transform.position; //.position je trenutna pozicija platforme

        if (tempA.y <= bound_Y1)//ako je trenutni y veći od granica, platforma je izašla iz ekrana
        {
            //ako je izašla sa ekrana želimo je deaktivirati
            gameObject.SetActive(false);
        }
    }
}