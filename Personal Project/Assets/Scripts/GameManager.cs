using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float spawnRangeX = 21.5f;
    private float spawnPosY = 0.8f;
    private float spawnPosZ = 18.0f;
    public GameObject [] shipPrefabs;

    public TextMeshProUGUI scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        InvokeRepeating("spawnRandomShip", 2, 1.5f);
        // UpdateScore(0);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        Debug.Log("Score: + score");
    }

    void spawnRandomShip()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

        int shipIndex = Random.Range(0, shipPrefabs.Length);
        Instantiate (shipPrefabs[shipIndex], spawnPos, shipPrefabs[shipIndex].transform.rotation);
    }
}
