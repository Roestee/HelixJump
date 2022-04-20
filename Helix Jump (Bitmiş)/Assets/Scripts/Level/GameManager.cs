using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject templet;

    public int RingCount
    {
        get
        {
            return ringCount;
        }
    }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI restartScoreText;


    public GameObject startPanel;
    public GameObject restartPanel;
    public GameObject nextLevelPanel;

    public GameObject Ball;

    private int score;
    private int ringCount;
    private int level = 1;
    private int bestScore;

    public void GameScore(int ringScore)
    {
        if(scoreText == null)
        {
            return;
        }

        score += ringScore;
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Level", level);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FailLevel()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (score > bestScore)
            PlayerPrefs.SetInt("BestScore", score);

        restartScoreText.text = "Score: " + score;

        score = 0;
        level = 1;

        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("isStart", 1);

        startPanel.SetActive(false);
        restartPanel.SetActive(true);
    }
    public void NextLevel()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (score > bestScore)
            PlayerPrefs.SetInt("BestScore", score);

        levelText.text = "Level " + level + " Complete";
        startPanel.SetActive(false);
        restartPanel.SetActive(false);
        nextLevelPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadNextLevel()
    {
        nextLevelPanel.SetActive(false);
        level++;
        PlayerPrefs.SetInt("Level", level);
        RestartGame();
    }

    private void LevelInclude()
    {
        if (5 > level && level >= 1)
            ringCount = 6;

        if (10 > level && level >= 5)
            ringCount = 8;

        if(15 > level && level >= 10)
            ringCount = 10;
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        templet = GameObject.FindGameObjectWithTag("Templet");
        level = PlayerPrefs.GetInt("Level", 1);

        LevelInclude();
        UpdateScore();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0).ToString();

        if (PlayerPrefs.GetInt("isStart", 0) != 0)
        {
            Time.timeScale = 1;
            startPanel.SetActive(false);
            restartPanel.SetActive(false);
            nextLevelPanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void UpdateScore()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = score.ToString();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startPanel.gameObject.SetActive(false);
        Ball.SetActive(true);
    }

    public void ExitGame()
    {
        PlayerPrefs.SetInt("isStart", 0);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Level", 1);

        Application.Quit();
    }
}
