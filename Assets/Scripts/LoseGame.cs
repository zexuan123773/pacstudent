using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    
    public void RestartPlay()
    {
        SceneManager.LoadScene("start menu");
    }
}
