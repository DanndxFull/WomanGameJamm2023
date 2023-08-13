using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador1 : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    private Rigidbody rb;
    private Controles controles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controles = GetComponent<Controles>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = controles.GetHorizontalInput();

        Vector2 movement = new Vector2(moveHorizontal,0);
        rb.velocity = movement * movementSpeed;
    }
    
    
}