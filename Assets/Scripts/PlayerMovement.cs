using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float RotationSpeed;
    float horizontalInput;
    float verticalInput;
    
    
    
    void Start()
    {
        
        
    }

    
    void Update()
    {
        if (!CollisonStones.IsLose)
        {
            horizontalInput = Input.GetAxis("Horizontal") * 4;
            verticalInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.Rotate(Vector3.up, Time.deltaTime * RotationSpeed * horizontalInput);
        }
    }
}
