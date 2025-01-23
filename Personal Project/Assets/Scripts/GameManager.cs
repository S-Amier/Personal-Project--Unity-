using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Private variables for spawn position and rate control.
    private float spawnRangeX = 21.5f; // Range for horizontal spawning.
    private float spawnPosY = 0.8f;    // Vertical position for spawning.
    private float spawnPosZ = 18.0f;   // Depth position for spawning.

    private float spawnRate = 4f;      // Time interval between ship spawns.
    private int score;                 // Tracks the player's score.

    // Public variables for game objects and UI elements.
    public GameObject[] shipPrefabs;       // Array of ship prefabs for spawning.
    public TextMeshProUGUI scoreText;      // Text UI for displaying the score.
    public TextMeshProUGUI gameoverText;   // Text UI for the game-over message.
    public bool isGameActive;              // Tracks whether the game is active.
    public Button restartButton;           // Button to restart the game.
    public GameObject titleScreen;         // Reference to the title screen UI.

    // Start is called before the first frame update
    void Start()
    {
        // Initialization logic could go here if needed.
    }

    // Starts the game with the selected difficulty.
    public void StartGame(int difficulty)
    {
        isGameActive = true;           // Sets the game state to active.
        score = 0;                     // Resets the score.
        spawnRate /= difficulty;       // Adjusts spawn rate based on difficulty.
        
        // Starts spawning ships at regular intervals.
        InvokeRepeating("spawnRandomShip", 2.0f, spawnRate);
        
        // Hides the title screen.
        titleScreen.gameObject.SetActive(false);

        // Updates the score display.
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Currently unused, available for frame-based logic if needed.
    }

    // Restarts the current scene.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Ends the game and displays the game-over UI.
    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);  // Shows the game-over message.
        isGameActive = false;                     // Stops the game state.
        restartButton.gameObject.SetActive(true); // Displays the restart button.
    }

    // Updates the player's score.
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;                   // Increments the score.
        scoreText.text = "Score: " + score;    // Updates the score display in the UI.
        Debug.Log("Score: " + score);          // Logs the score for debugging.
    }

    // Spawns a random ship at a random position.
    void spawnRandomShip()
    {
        if (isGameActive) // Ensures ships only spawn while the game is active.
        {
            // Generates a random spawn position within the defined range.
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);

            // Selects a random ship prefab to spawn.
            int shipIndex = Random.Range(0, shipPrefabs.Length);

            // Instantiates the selected ship prefab at the calculated position.
            Instantiate(shipPrefabs[shipIndex], spawnPos, shipPrefabs[shipIndex].transform.rotation);
        }
    }
}