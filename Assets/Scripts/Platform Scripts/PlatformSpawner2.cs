using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner2 : MonoBehaviour
{
    public GameObject platformPrefab; //obična platforma
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;  //omogućujem unos niza za left i right platformu
    public GameObject breakablePlatform;
    

    public float platform_Spawn_Timer = 1.0f;//svake 1.3 sekunde
    private float current_Platform_Spawn_Timer;

    private int platform_Spawn_Count;
    public float min_X = -7f, max_X = 7f;  //spawnamo platgorme između ovih granica
    
    void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();  //počni stvarat platforme
        
    }

    void SpawnPlatforms()
    {
        current_Platform_Spawn_Timer += Time.deltaTime;
        //svaki frame na current_Platform_Spawn_Timer dodajemo Time.deltaTime u update metodi
        //i kada current postane veci od platform_Spawn_Timer izvodi se if uvjet

        if (current_Platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            platform_Spawn_Count++;  //kontroliramo spawnanje
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);  //da se spawna između X-eva

            GameObject newPlatform = null;
            if (platform_Spawn_Count < 2)  //dok je count manje od nule stvaramo obicnu platformu
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);

            }
            else if (platform_Spawn_Count == 2)//kada je 2 onda ili spawnaj obični platformu ili movingPlatform
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity); //obicna //temp za pozicju, quat za rotaciju
                }
                else
                {
                    newPlatform = Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], temp, Quaternion.identity); //moving platform
                }
            }
            else if (platform_Spawn_Count == 3) //ili obicnu ili spike platformu
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity); //obicna
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity); //spike platform
                }
            }
            else if (platform_Spawn_Count == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity); //obicna
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity); //breakable platform
                }
                platform_Spawn_Count = 0;
            }

            //newPlatform.transform.parent = transform;  //kako bi svaka platforma bila dijete od Platform spawnera da nam ne bude neuredna hijerarhija
            if (newPlatform)//ovo je jednako
                newPlatform.transform.parent = transform;
            current_Platform_Spawn_Timer = 0f;//resetiramo timer da svaki put se vrati na nulu, čeka koliko treba i stvori opet
        }//stvara platformu
    }
}
