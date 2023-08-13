using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 enum Canshinna{
    canchaIZQ,
    canchaDER
}

public class Goal : MonoBehaviour
{
    //variables goles
    public int golesIZQ = 0;
    public int golesDER = 0;

    [SerializeField] private TextMeshProUGUI golesTextoIZQ, golesTextoDER;


    public Transform player1;
    public Transform player2;
    public Transform ball;
    [SerializeField] private Canshinna cancha;
    [SerializeField] private GameObject imageGool;
    [SerializeField] private RandomTransition random;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("fuchi"))
        {
            if(cancha == Canshinna.canchaIZQ)
            {
                golesIZQ++;
                golesTextoIZQ.text = golesIZQ.ToString();

            }
            if (cancha == Canshinna.canchaDER)
            {
                golesDER++;
                golesTextoDER.text = golesDER.ToString();
            }
            StartCoroutine(ResetPlayers());
        }
    }


    IEnumerator ResetPlayers()
    {
        imageGool.SetActive(true);
        player1.position = new Vector3(-4, 0.5f, 0);
        player2.position = new Vector3(4, 0.5f, 0);
        ball.position = new Vector3(0, 0.5f, 0);
        player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        random.enabled = false;
        yield return new WaitForSeconds(1);
        imageGool.SetActive(false);
        random.enabled = true;
    }

}
