using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GolCounter : MonoBehaviour
{
    public int golesIZQ = 0;
    public int golesDER = 0;

    [SerializeField] private TextMeshProUGUI golesTextoIZQ, golesTextoDER;
    
    public void GOL(int cansha)
    {
        if(cansha == 1)
        {
            golesIZQ++;
            golesTextoIZQ.text = golesIZQ.ToString();
        }
        else if(cansha == 2)
        {
            golesDER++;
            golesTextoDER.text = golesDER.ToString();
        }
    }
}
