using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    //private float startTime;           //for increasing timer
    public Text timerText;
    public GameObject gameOverUI;
    public float timeLeft;
    void Start()
    {
        //startTime = Time.time;
    }
    // Update is called once per frame
    void Update () {
        /*
        //for increasing timer

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString();

        timerText.text = minutes + ":" + seconds;
        */
        timeLeft -= Time.deltaTime;
        string minutes = ((int)timeLeft / 60).ToString();
        string seconds = (timeLeft % 60).ToString("f0");
        timerText.text = minutes + ":" + seconds;
        if(timeLeft<0)
        {
            gameOver();
            Time.timeScale = 0f;
        }
	}
    void gameOver()
    {
        
        gameOverUI.SetActive(true);
    }
}
