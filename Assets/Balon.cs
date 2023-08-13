using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balon : MonoBehaviour
{
    public AudioSource SonicBalon;

    private void OnCollisionEnter(Collision collision)
    {
        if (!SonicBalon.isPlaying)
        {
            SonicBalon.Play();
        }

    }
}
