using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    GameObject timerCanvasObject;
    Text timerText;
    private static int score = 0;
    public float timer;
    //private static int highScore = 0;

    void Start()
    {
        timerCanvasObject = GameObject.Find("Timer");
        timerText = timerCanvasObject.GetComponent<Text>();
    }
    void Update()
    {
        if (timer > 0)
        {
            timerText.text = "+" + ((int)timer).ToString();
            timer -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {


    }
    public void PlayGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void NewLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        score = score + (int)timer;
    }
    public void ReloadLevel()
    {
        //if (lives > 0)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
        //else
        //{
        //    SceneManager.LoadScene(1);
        //}
    }
    public void ScoreManager()
    {
        string showScore = "";

        if(score < 10)
        {
            showScore = "0" + score.ToString();
        }
        else
        {
            showScore = score.ToString();
        }

    }
}
