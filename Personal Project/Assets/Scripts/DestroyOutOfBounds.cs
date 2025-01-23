using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Defines the upper and lower bounds for object positions in the Z-axis.
    private float topBound = 18.0f;
    private float lowerBound = -9.0f;

    // Reference to the GameManager script to handle game over logic.
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Finds the GameManager object in the scene and gets its GameManager component.
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the object's position exceeds the upper bound.
        if (transform.position.z > topBound)
        {
            // Destroys the object if it moves beyond the upper bound.
            Destroy(gameObject);
        } 
        // Checks if the object's position falls below the lower bound.
        else if (transform.position.z < lowerBound)
        {
            // If the object is tagged as "Enemy", triggers the GameOver function in GameManager.
            if (gameObject.CompareTag("Enemy"))
            {
                gameManager.GameOver();
            }
            // Destroys the object regardless of whether it's an enemy or not.
            Destroy(gameObject);
        }
    }
}