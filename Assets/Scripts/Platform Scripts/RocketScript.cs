using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    private float move_Speed = 6f;
    public float bound_X = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveRocket();
    }

    void MoveRocket()//mičemo raketu
    {
        Vector2 temp = transform.position; //.position je trenutna pozicija platforme
        temp.x += move_Speed * Time.deltaTime; //mičemo za speed i deltaTime (svaki frame)
        transform.position = temp; //nova pozicija je temp

        if (temp.x >= bound_X)//ako je trenutni y veći od granica, platforma je izašla iz ekrana
        {
            //ako je izašla sa ekrana želimo je deaktivirati
            gameObject.SetActive(false);
        }
    }
}
