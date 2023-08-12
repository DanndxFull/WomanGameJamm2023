using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float moveSpeed, forceJump;
    private Vector3 direction;
    [SerializeField] private LayerMask layer;
    GameInputs inputs;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputs = GetComponent<GameInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = inputs.GetMovingX();
        float moveY = inputs.GetMovingY();

        direction = new Vector3(moveX, 0, moveY);

        Vector3 moveVector = transform.TransformDirection(direction) * moveSpeed;
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);
        if (inputs.GetInputJump())
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
