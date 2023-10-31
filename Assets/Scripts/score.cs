using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class score : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scoreText;
    public static int theScore;

    // Update is called once per frame

    void Start()
    {
        InvokeRepeating("scoreIncrease", 1f, 1f);
    }
    void Update()
    {
        
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;
        if (score.theScore == 60)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay2");//loadamo sljedeci scene kada stisnemo na play button
            score.theScore = 62;
        }
        if (score.theScore == 130)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay3"); //loadamo sljedeci scene kada stisnemo na play button
            score.theScore = 132;
        }
        if (score.theScore == 200)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Asc"); //loadamo sljedeci scene kada stisnemo na play button
            score.theScore = 202;
        }

    }

    void scoreIncrease()
    {
        score.theScore += 2;
    }
    
}
