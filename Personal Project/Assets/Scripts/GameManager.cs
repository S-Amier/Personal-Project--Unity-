using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //private variables
    private float spawnRangeX = 21.5f;
    private float spawnPosY = 0.8f;
    private float spawnPosZ = 18.0f;

    private float spawnRate = 4f;
    private int score;

    //Public variables
    public GameObject [] shipPrefabs;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        InvokeRepeating("spawnRandomShip", 2.0f, spawnRate);
        titleScreen.gameObject.SetActive(false);
        UpdateScore(0);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);
    }

    void spawnRandomShip()
    {
        if (isGameActive == true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

            int shipIndex = Random.Range(0, shipPrefabs.Length);
            Instantiate (shipPrefabs[shipIndex], spawnPos, shipPrefabs[shipIndex].transform.rotation);
        }
        
    }
}
