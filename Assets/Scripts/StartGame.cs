using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    public void StartPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Startlevel1()
    {
        SceneManager.LoadScene("level 1");
    }
    public void Startlevel2()
    {
        SceneManager.LoadScene("level 2");
    }
}
