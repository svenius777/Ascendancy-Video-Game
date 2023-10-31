using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    // bounds na treba na lijevo i desno i za dole i gore
    public float min_X = -8f, max_X = 8f, min_Y = -5f;
    private bool out_Of_Bounds;

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > max_X) //ako pređemo granicu na X-osi onda cemo se resetirat nazad
            temp.x = max_X;

        if (temp.x < min_X)
            temp.x = min_X;

        transform.position = temp; //moramo resetirati poziciju na našu trenutnu poziciju

        if (temp.y <= min_Y)//provjerava dali smo pali
        {
            if (!out_Of_Bounds)//ako NISMO izvan granica
            {
                out_Of_Bounds = true;
                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
            }
        }
    }//provjeri granice

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "DeadlySpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();
        }
    }
}
