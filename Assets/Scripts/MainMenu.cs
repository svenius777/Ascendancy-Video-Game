using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//loadamo sljedeci scene kada stisnemo na play button
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
