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

    [SerializeField] private int view = 0;

    [SerializeField] private Player1Movement player1Movement;
    [SerializeField] private Player2Movement player2Movement;

    [SerializeField] private List<Movement3D> movement3Ds;
    [SerializeField] private List<GameInputs> gameInputs;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        playTime += Time.deltaTime;
        if (currentTime > timeToChange)
        {
            switch (view)
            {
                case 0:
                    {
                        TransitionGameFIFA();
                        view = 1;
                        break;
                    }
                case 1:
                    {
                        TransitionFrontal();
                        view = 2;
                        break;
                    }
                case 2:
                    {
                        TransitionGameFIFA();
                        view = 3;
                        break;
                    }
                case 3:
                    {
                        TransitionCenital();
                        view = 0;
                        break;
                    }
            }
            currentTime = 0;
        }
        if (playTime > 34)
        {
            timeToChange = 10;
        }
        if (playTime > 94)
        {
            timeToChange = 8;
        }
        if (playTime > 116)
        {
            timeToChange = 6;
        }
    }

    public void TransitionCenital()
    {
        cameraHoolder.DORotate(new Vector3(45, 0, 0), 2).OnComplete(() => cam.orthographic = true);
        multiple.NewOffset(0, 8, 0);
        ToggleMovement3D(false);
        ToggleMovementCenital(true);
    }
    public void TransitionGameFIFA()
    {
        cameraHoolder.DORotate(new Vector3(0, 0, 0), 2).OnComplete(() => cam.orthographic = false);
        multiple.NewOffset(0, 8, -10);
        ToggleMovementCenital(false);
        ToggleMovement3D(true);
    }
    public void TransitionFrontal()
    {
        cameraHoolder.DORotate(new Vector3(-45, 0, 0), 2).OnComplete(() => cam.orthographic = true);
        multiple.NewOffset(0, 1, -40);
        ToggleMovementCenital(false);
        ToggleMovement3D(false);
    }


    private void ToggleMovement3D(bool state)
    {
        for(int i = 0; i < 1; i++)
        {
            movement3Ds[i].enabled = state;
        }
        for (int i = 0; i < 1; i++)
        {
            gameInputs[i].enabled = state;
        }
    }

    public void ToggleMovementCenital(bool state)
    {
        player1Movement.enabled = state;
        player2Movement.enabled = state;
    }
}
