using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 movementInput;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movementInput = Vector3.zero;
        //Z Axis
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementInput.z = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movementInput.z = -1;
        }

        //X Axis
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movementInput.x = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementInput.x = -1;
        }
    }

    private void FixedUpdate()
    {
        Move(movementInput);
    }

    void Move(Vector3 direction)
    {
        rb.AddForce(direction.normalized * speed, ForceMode.Acceleration);
    }
}
