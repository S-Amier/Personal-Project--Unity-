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

    // Projectiles explode on impact powerups and enemies
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

