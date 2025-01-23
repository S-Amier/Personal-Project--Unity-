using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveForward : MonoBehaviour
{
    // Public variable to set the movement speed of the object in Unity Inspector.
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization logic can be added here if needed.
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the object forward (in the upward direction in this case) at a constant speed.
        // Time.deltaTime ensures the movement is frame-rate independent.
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}