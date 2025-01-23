using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    // Reference to the GameManager script to update the game state and score.
    public GameManager gameManager;

    // The score value awarded for destroying this enemy, set in the Inspector.
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        // Finds the GameManager object in the scene and gets its GameManager component.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Currently unused, but available for per-frame logic if needed.
    }

    // Handles collision logic when the enemy is hit by another object.
    private void OnTriggerEnter(Collider other)
    {
        // Checks if the object colliding with the enemy is tagged as "Projectile".
        if (other.gameObject.CompareTag("Projectile"))
        {
            // Destroys the enemy GameObject.
            Destroy(gameObject);

            // Destroys the projectile GameObject.
            Destroy(other.gameObject);

            // Updates the player's score by the value of this enemy.
            gameManager.UpdateScore(pointValue);
        }
    }
}