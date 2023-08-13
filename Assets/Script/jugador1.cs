using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador1 : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float forceJump = 10.0f;
    private Rigidbody rb;
    private Controles1 controles;
    [SerializeField] private LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controles = GetComponent<Controles1>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = controles.GetHorizontalInput();

        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.velocity = movement * movementSpeed;
        if (controles.GetInputJump())
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.5f, layer))
        {
            rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
        }
    }

    
}
