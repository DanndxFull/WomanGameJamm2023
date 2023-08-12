using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RandomTransition : MonoBehaviour
{
    [SerializeField] private float timeToChange;
    private float currentTime;
    private float playTime;

    [SerializeField] private Transform cameraHoolder;
    [SerializeField] private Camera cam;

    [SerializeField] private MultipleTargetCamera multiple;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        //playTime += Time.deltaTime;
        if (currentTime > timeToChange)
        {
            TransitionGame();
            currentTime = 0;
            timeToChange -= 15;
        }
    }

    public void TransitionGame()
    {
        cameraHoolder.DORotate(new Vector3(-45, 0, 0), 2).OnComplete(() => cam.orthographic = true);
        multiple.NewOffset(0,1,-40);
    }
}
