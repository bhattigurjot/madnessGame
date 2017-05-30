using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    GameObject timerCanvasObject;
    GameObject scoreCanvasObject;
    GameObject livesCanvasObject;
    Text livesText;
    Text timerText;
    Text scoreText;
    string showScore = "SCORE: 0";
    public static bool isGameMenu = true;
    public static int score = 0;
    public float timer;
    public static int lives = 3;
    //private static int highScore = 0;

    void Start()
    {
        //Scene scene = SceneManager.GetActiveScene();
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().name == "Instructions")
        {
            isGameMenu = true;
        }
        else
        {
            isGameMenu = false;
        }
        if (!isGameMenu)
        {
            timerCanvasObject = GameObject.Find("Timer");
            timerText = timerCanvasObject.GetComponent<Text>();
            scoreCanvasObject = GameObject.Find("Score");
            scoreText = scoreCanvasObject.GetComponent<Text>();
            livesCanvasObject = GameObject.Find("Lives");
            livesText = livesCanvasObject.GetComponent<Text>();
            ScoreManager();
        }

        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            if (!isGameMenu) timerText.enabled = false;
        }
    }
    //void Awake()
    //{
    //    DontDestroyOnLoad(transform.gameObject);
    //    GameObject ScoreCanvas = GameObject.Find("ScoreCanvas");
    //    DontDestroyOnLoad(ScoreCanvas.transform);
    //}
    void Update()
    {
        if (timer > 0 && SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().name != "Instructions")
        {
            timerText.text = "+" + ((int)timer).ToString();
            timer -= Time.deltaTime;

            scoreText.text = showScore;
            livesText.text = "LIVES: " + lives.ToString() + "/3";
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
            //SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
            SceneManager.LoadScene("Game Over");
        }
    }

    public void PlayGameButton()
    {
        isGameMenu = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReplayGame()
    {
        score = 0;
        lives = 3;
        SceneManager.LoadScene(1);
    }

    public void NewLevel()
    {
        score = score + (int)timer;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ScoreManager()
    {
        if(score < 10)
        {
            showScore = "SCORE: " + "0" + score.ToString();
        }
        else
        {
            showScore = "SCORE: " + score.ToString();
        }

    }
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
