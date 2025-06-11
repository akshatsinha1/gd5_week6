using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    float spawnRate = 1;

    [SerializeField] int score = 5;
    public int lives = 3;
    public TMP_Text scoreText , livesText;

    public GameObject gameOverUI, inGameUI;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTargets());

        scoreText.text = "Score " + score;
    }

    IEnumerator SpawnTargets()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            spawnRate = Random.Range(0.5f, 1);
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
        gameOverUI.SetActive(true);
        inGameUI.SetActive(false);
    }
}
