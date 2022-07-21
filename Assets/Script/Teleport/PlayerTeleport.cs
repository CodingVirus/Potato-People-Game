using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject currentTeleporter;
    public GameObject fadeEffect;
    public bool transferStart = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(transferStart == true)
        {
            if(other.CompareTag("Door"))
            {
                currentTeleporter = other.gameObject;
                Invoke("DoorEnter", 0.5f);
                Debug.Log("이동");
            }
        }
    }

    public void DoorEnter() 
    {
        if(currentTeleporter == null)
        {
            transferStart = false;
            Debug.Log("Moving : 이동 false");
        }
        else
        {
            //currentTeleporter.GetComponent<AudioSource>().Play();
            fadeEffect.GetComponent<FadeScript>().Fade();
            //currentTeleporter.GetComponent<AudioSource>().Play();
            Invoke("Moving", 1.4f);
        }
    }

    private void Moving()
    {
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        this.GetComponent<PlayerMouseControll>().target = transform.position;
        this.GetComponent<PlayerMouseControll>().speed = 5.0f;
        transferStart = false;
        currentTeleporter = null;
        
    }

    private void OnTriggerExit2D() 
    {
        currentTeleporter = null;
        Debug.Log("Exit : null");
    }

}
