using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private float move_Speed = 0.5f;  //brzina platforme
    public float bound_Y = 6f;
     //kada dođe na 6 na Y-osi platofrma više neće biti vidljiva

    public bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform, is_Asteroid;
    //određujemo koja platforma koristi ovu skriptu

    private Animator anim;


   

    

    private void Awake()
    {
        if (is_Breakable)
            anim = GetComponent<Animator>();
        InvokeRepeating("speedIncrease", 2f, 2f);
    }

    void speedIncrease()
    {
        move_Speed = move_Speed + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //MoveAsteroid();
    }

    /*
     void MoveAsteroid()
    {
        Vector2 tempA = transform.position; //.position je trenutna pozicija platforme
        tempA.y -= move_Speed * Time.deltaTime; //mičemo za speed i deltaTime (svaki frame)
        transform.position = tempA; //nova pozicija je temp

        if (tempA.y <= bound_Y1)//ako je trenutni y veći od granica, platforma je izašla iz ekrana
        {
            //ako je izašla sa ekrana želimo je deaktivirati
            gameObject.SetActive(false);
        }
    }
     */




    void Move()//mičemo platformu
    {
        Vector2 temp = transform.position; //.position je trenutna pozicija platforme
        temp.y += move_Speed * Time.deltaTime; //mičemo za speed i deltaTime (svaki frame)
        transform.position = temp; //nova pozicija je temp

        if (temp.y >= bound_Y)//ako je trenutni y veći od granica, platforma je izašla iz ekrana
        {
            //ako je izašla sa ekrana želimo je deaktivirati
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);//nakon 0.3 pozivamo DeactivateGameObject nakon 0.3 sekunde
    }

    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")//provjerava jesmo li se sudarili sa playerom
        {
            if (is_Spike || is_Asteroid)
            {
                target.transform.position = new Vector2(1000f, 1000f); //stavljamo poziciju playera na 1000,1000 kako bismo ga makli iz scene
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (is_Breakable)//sletjeli smo na breakablePlatform
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }

            if (is_Platform)
            {
                SoundManager.instance.LandSound();
            }
        }
    }

    void OnCollisionStay2D(Collision2D target)//poziva se svaki frame kada je player na moving platformi
    {
        if (target.gameObject.tag == "Player")//testiramo ako je player sletio na moving platformu
        {
            if (moving_Platform_Left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }

            if (moving_Platform_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }
}
