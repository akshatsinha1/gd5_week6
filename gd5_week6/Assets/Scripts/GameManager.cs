using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    float spawnRate = 2;

    [SerializeField] int score = 5;
    public int lives = 3;
    public TMP_Text scoreText , livesText, gameOverScoreText, highScoreText;

    public GameObject gameOverUI, inGameUI, titleUI;
    public bool isGameActive = true;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

       
    }

    IEnumerator SpawnTargets()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }

    public void UpdateScore(int scoreToAdd, int livesToLose)
    {
        score += scoreToAdd;
        lives -= livesToLose;
        livesText.text = "Lives " + lives;
        scoreText.text = "Score " + score;
    }

    public void GameOver()
    {
        gameOverScoreText.text = "Current Score " + score;

        if(score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        highScoreText.text = "Highscore " + PlayerPrefs.GetInt("Highscore");

        isGameActive = false;
        gameOverUI.SetActive(true);
        inGameUI.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        StartCoroutine(SpawnTargets());
        score = 0;
        lives = 5;

        scoreText.text = "Score " + score;
        livesText.text = "Lives " + lives;

        titleUI.SetActive(false);
        inGameUI.SetActive(true);

        spawnRate /= difficulty;

    }
}
