using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject currentTeleporter;
    public GameObject fadeEffect;
    public bool transferStart = false;
    public bool T_camera = false;

    //카메라 설정
    //public BoxCollider2D targetBound;

    private void Start() 
    {
        //theCamera = FindObjectOfType<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(transferStart == true)
        {
            if(other.CompareTag("Door"))
            {
                currentTeleporter = other.gameObject;
                Invoke("DoorEnter", 0.5f);
            }
        }
    }

    public void DoorEnter() 
    {
        this.GetComponent<PlayerMouseControll>().speed = 0.0f;
        //currentTeleporter.GetComponent<AudioSource>().Play();
        fadeEffect.GetComponent<FadeScript>().Fade();
        //T_camera = true;
        //currentTeleporter.GetComponent<AudioSource>().Play();
        Invoke("Moving", 1.4f);
    }

    private void Moving()
    {
        //theCamera.SetBound(targetBound);

        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        this.GetComponent<PlayerMouseControll>().target = transform.position;
        this.GetComponent<PlayerMouseControll>().speed = 5.0f;
        transferStart = false;
        currentTeleporter = null;
    }

}
