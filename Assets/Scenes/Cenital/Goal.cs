using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 enum Canshinna{
    canchaIZQ,
    canchaDER
}

public class Goal : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Transform ball;
    [SerializeField] Canshinna cancha;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("fuchi"))
        {
            if(cancha == Canshinna.canchaIZQ)
            {
                Debug.Log("fucuiado  -   GOOOOOOOAL IZQ");
            }
            if (cancha == Canshinna.canchaDER)
            {
                Debug.Log("fucuiado  -   GOOOOOOOAL DER");
            }
            player1.position = new Vector3(-9, 2, 0);
            player2.position = new Vector3(9, 2, 0);
            ball.position = new Vector3(0, 0, 0);
        }
    }

}
