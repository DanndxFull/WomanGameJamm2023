using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterFalling : MonoBehaviour
{
    [SerializeField] private float fallMultiplayer = 2.5f;
    [SerializeField] private float lowJumpMultiplayer = 2;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplayer - 1) * Time.deltaTime;
        }else if(rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.C))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplayer - 1) * Time.deltaTime;
        }
    }
}
