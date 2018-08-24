using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;
    public GameObject gameOverUI;
    public float timeLeft = 10f;
    void Start()
    {
        //startTime = Time.time;
    }
    // Update is called once per frame
    void Update () {
        //float t = Time.time - startTime;

        // string minutes = ((int)t / 60).ToString();
        //string seconds = (t % 60).ToString();

        // timerText.text = minutes + ":" + seconds;
        timeLeft -= Time.deltaTime;
        string seconds = timeLeft.ToString();
        timerText.text = seconds;
        if(timeLeft<0)
        {
            gameOver();
        }
	}
    void gameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
}
