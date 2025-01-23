using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DifficulyButton : MonoBehaviour
{
    // Reference to the GameManager script for starting the game with the selected difficulty.
    private GameManager gameManager;

    // Reference to the Button component attached to this GameObject.
    private Button button;

    // The difficulty level assigned to this button (set in the Inspector).
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the Button component attached to this GameObject.
        button = GetComponent<Button>();
        
        // Adds an event listener to the button to call the SetDifficulty method when clicked.
        button.onClick.AddListener(SetDifficulty);

        // Finds the GameManager object in the scene and gets its GameManager component.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Sets the game difficulty and starts the game when the button is clicked.
    public void SetDifficulty()
    {
        // Calls the StartGame method on the GameManager, passing the assigned difficulty level.
        gameManager.StartGame(difficulty);
    }
}
