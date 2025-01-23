using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyUponImpact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Handles the logic when the object collides with a trigger collider.
    private void OnTriggerEnter(Collider other)
    {
        // Checks if the object the projectile collides with has the tag "Powerup".
        if (other.gameObject.CompareTag("Powerup"))
        {
            // Destroys the powerup object on impact.
            Destroy(other.gameObject);
            // Destroys the projectile object itself.
            Destroy(gameObject);
        }
    }
}
