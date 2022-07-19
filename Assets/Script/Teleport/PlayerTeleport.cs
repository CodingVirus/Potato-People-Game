using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    public GameObject fadeEffect;
    public bool transferStart = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(transferStart == true)
        {
            if(other.CompareTag("Door"))
            {
                currentTeleporter = other.gameObject;
                DoorEnter();
            }
        }
    }

    private void DoorEnter() 
    {
        //currentTeleporter.GetComponent<AudioSource>().Play();
        fadeEffect.GetComponent<FadeScript>().Fade();
        this.GetComponent<PlayerMouseControll>().playerMove = false;
        //currentTeleporter.GetComponent<AudioSource>().Play();
        Invoke("Moving", 1.2f);
    }

    private void Moving()
    {
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        this.GetComponent<PlayerMouseControll>().target = transform.position;
        transferStart = false;
        currentTeleporter = null;
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if(other.CompareTag("Door"))
    //    {
    //        currentTeleporter = null;
    //    }
    //}

}
