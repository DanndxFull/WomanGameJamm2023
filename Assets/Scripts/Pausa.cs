using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    private bool isPaused;
    // Update is called once per frame

    private void Start()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) 
            {
                Time.timeScale = 0;
                menuPanel.SetActive(true);
                isPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                menuPanel.SetActive(false);
                isPaused = false;
            }
        }
    }
}
