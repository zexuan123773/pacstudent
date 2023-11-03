/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DotCounter : MonoBehaviour
{
    public int dotCountThreshold = 10;
    private int dotCount;
    private int dotCountCurrentTime;

    public Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        dotCount = GameObject.FindGameObjectsWithTag("dot").Length;
        textComponent.text = "Eat Count Count";
    }

    

    // Update is called once per frame
    void Update()
    {
        dotCountCurrentTime = GameObject.FindGameObjectsWithTag("dot").Length;
        
        if(dotCount - dotCountCurrentTime > dotCountThreshold)
        {
            
            //UnityEditor.SceneManagement.EditorSceneManager.LoadScene("win game");
            SceneManager.LoadScene("win game");   // 使用 SceneManager.LoadScene 加载场景
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DotCounter : MonoBehaviour
{
    public int dotCountThreshold = 10;
    private int dotCount;
    private int dotCountCurrentTime;
    private int showCount;

    public Text textComponent;
    public string loadSceneName;

    // Start is called before the first frame update
    void Start()
    {
        dotCount = GameObject.FindGameObjectsWithTag("dot").Length;
        textComponent.text = "Eat Count: " + dotCountCurrentTime + "/" + dotCount;
        showCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dotCountCurrentTime = GameObject.FindGameObjectsWithTag("dot").Length;
        showCount = dotCount - dotCountCurrentTime;

        textComponent.text = "Eat Count: " + showCount + "/" + dotCount;

        if (dotCount - dotCountCurrentTime > dotCountThreshold)
        {
            SceneManager.LoadScene(loadSceneName);
        }
    }
}
