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
    public static int lives = 3;
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

    public void LoseLive()
    {
        lives -= 1;
        if (lives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            lives = 3;
            // TODO - set this to game over scene - currently it is setting to first scene in build
            SceneManager.LoadScene(0);
        }
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
