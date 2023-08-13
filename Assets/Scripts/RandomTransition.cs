using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


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
    
    [SerializeField] private List<jugador1> jugador1s;
    [SerializeField] private List<Controles1> controles1s;

    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    [SerializeField] private Transform balon;

    [SerializeField] private Rigidbody player1Rb;
    [SerializeField] private Rigidbody player2Rb;
    [SerializeField] private Rigidbody balonRb;
    [SerializeField] private GameObject ObjetoCam;

    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private GameObject panelFinJuego;
    [SerializeField] private MeshRenderer mesh;
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        playTime += Time.deltaTime;
        timer.text = "Time:"+(((int)playTime)).ToString();
        if (currentTime > timeToChange)
        {
            balonRb.velocity = Vector3.zero;
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
        if (playTime > 120)
        {
            Time.timeScale = 0;
            panelFinJuego.SetActive(true);
        }
    }

    public void TransitionCenital()
    {
        StartCoroutine(animacionCambio());   
        cameraHoolder.DORotate(new Vector3(45, 0, 0), 2).OnComplete(() => cam.orthographic = true);
        multiple.NewOffset(0, 8, 0);
        ToggleMovement3D(false);
        ToggleMovementFrontal(false);
        ToggleMovementCenital(true);
        mesh.enabled = true;
        player1.position = new Vector3(player1.position.x, 1, player1.position.z);
        player2.position = new Vector3(player2.position.x, 1, player2.position.z);
        balon.position = new Vector3(balon.position.x,1, balon.position.z);
    }
    public void TransitionGameFIFA()
    {
        StartCoroutine(animacionCambio());
        cameraHoolder.DORotate(new Vector3(0, 0, 0), 2).OnComplete(() => cam.orthographic = false);
        multiple.NewOffset(0, 8, -10);
        ToggleMovementCenital(false);
        ToggleMovementFrontal(false);
        ToggleMovement3D(true);
        mesh.enabled = true;
    }
    public void TransitionFrontal()
    {
        StartCoroutine(animacionCambio());
        cameraHoolder.DORotate(new Vector3(-45, 0, 0), 2).OnComplete(() => cam.orthographic = true);
        multiple.NewOffset(0, 1, -40);
        ToggleMovementCenital(false);
        ToggleMovement3D(false);
        ToggleMovementFrontal(true);
        player1.position = new Vector3(player1.position.x, player1.position.y, 0);
        player2.position = new Vector3(player2.position.x, player2.position.y, 0);
        balon.position = new Vector3(balon.position.x, balon.position.y, 0);
        mesh.enabled = false;
    }


    private void ToggleMovement3D(bool state)
    {
        for (int i = 0; i <= 1; i++)
        {
            movement3Ds[i].enabled = state;
        }
        for (int i = 0; i <= 1; i++)
        {
            gameInputs[i].enabled = state;
        }
        player1Rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        player2Rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public void ToggleMovementCenital(bool state)
    {
        player1Movement.enabled = state;
        player2Movement.enabled = state;        
        player1Rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        player2Rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public void ToggleMovementFrontal(bool state)
    {
        for (int i = 0; i <= 1; i++)
        {
            jugador1s[i].enabled = state;
        }
        for (int i = 0; i <= 1; i++)
        {
            controles1s[i].enabled = state;
        }
        player1Rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ |
            RigidbodyConstraints.FreezePositionZ;
        player2Rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ |
            RigidbodyConstraints.FreezePositionZ;
        balonRb.constraints = RigidbodyConstraints.FreezePositionZ;
    }

    private IEnumerator animacionCambio(){
        player1Rb.velocity = Vector3.zero;
        player2Rb.velocity = Vector3.zero;
        balonRb.velocity = Vector3.zero;
        player1Rb.isKinematic = true;
        player2Rb.isKinematic = true;
        balonRb.isKinematic = true;
        ObjetoCam.SetActive(true);
        yield return new WaitForSeconds(2);
        ObjetoCam.SetActive(false);
        player1Rb.isKinematic = false;
        player2Rb.isKinematic = false;
        balonRb.isKinematic = false;
    }
}
