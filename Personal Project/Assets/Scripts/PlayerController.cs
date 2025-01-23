using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Scripts : MonoBehaviour
{
    // Private variables
    private Rigidbody playerRb;                  // Reference to the player's Rigidbody component.
    private float speed = 15.0f;                 // Movement speed of the player.
    private float xRange = 21.5f;                // Horizontal boundary for the player's movement.
    private GameManager gameManager;             // Reference to the GameManager script.

    // Public variables
    public GameObject projectilePrefab;          // Prefab for the projectile to be instantiated.

    // Start is called before the first frame update
    void Start()
    {
        // Gets the Rigidbody component attached to the player.
        playerRb = GetComponent<Rigidbody>();

        // Finds the GameManager object in the scene and gets its GameManager component.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the game is active before allowing player input.
        if (gameManager.isGameActive)
        {
            // Gets horizontal input from the player.
            float horizontalInput = Input.GetAxis("Horizontal");

            // Moves the player left or right based on input.
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

            // Shoots a projectile when the Space key is pressed.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Instantiates a projectile at the player's current position.
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            }

            // Prevents the player from moving out of bounds on the left side.
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            // Prevents the player from moving out of bounds on the right side.
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
        }
    }

    // Handles collision logic when the player collides with an object.
    private void OnCollisionEnter(Collision collision)
    {
        // Checks if the collision object is tagged as "Enemy".
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Logs a message to the console.
            Debug.Log("Player collides with enemy");

            // Ends the game by calling GameOver from the GameManager.
            gameManager.GameOver();
        }
    }
}
