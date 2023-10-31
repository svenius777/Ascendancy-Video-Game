using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    public void RestartGame()
    {
        Invoke("RestartAfterTime", 2f); //želimo pozvati GameManager kada player umre
        
    }

    void RestartAfterTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
        score.theScore = 0;
    }
}
