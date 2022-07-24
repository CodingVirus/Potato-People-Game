using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject currentTeleporter;
    public GameObject fadeEffect;
    public bool transferStart = false;
    public bool fade = true;
    
    //public bool T_camera = false;
    private CameraFollow theCamera;

    private void Awake() 
    {
        theCamera = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(transferStart == true)
        {
            //if(other.CompareTag("Door"))
            //{
                currentTeleporter = other.gameObject;
                Invoke("DoorEnter", 0.5f);
                Debug.Log("이동");
            //}
            //else
            //{
            //    currentTeleporter = other.gameObject;
            //    Invoke("DoorEnter", 0.5f);
            //    Debug.Log("이동");
            //}
        }
    }

    public void DoorEnter() 
    {
        if(fade == true)
        {
            Invoke("FadeEffect", 1.0f);
        }
        if(currentTeleporter == null)
        {
            transferStart = false;
            Debug.Log("Moving : 이동 false");
            fade = false;
        }
    }

    private void Moving()
    {
        CameraMove();
        Debug.Log("moving 시작");
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        this.GetComponent<PlayerMouseControll>().target = transform.position;
        this.GetComponent<PlayerMouseControll>().speed = 5.0f;
        transferStart = false;
        currentTeleporter = null;
        
    }

    private void FadeEffect()
    {
        //currentTeleporter.GetComponent<AudioSource>().Play();
        fadeEffect.GetComponent<FadeScript>().Fade();
        Debug.Log("fade");
        //currentTeleporter.GetComponent<AudioSource>().Play();
        Invoke("Moving", 1.4f);
    }

    private void CameraMove()
    {
        //T_camera = true;
        theCamera.limitMinX = currentTeleporter.GetComponent<Teleporter>().T_limitMinX;
        theCamera.limitMaxX = currentTeleporter.GetComponent<Teleporter>().T_limitMaxX;
        theCamera.limitMinY = currentTeleporter.GetComponent<Teleporter>().T_limitMinY;
        theCamera.limitMaxY = currentTeleporter.GetComponent<Teleporter>().T_limitMaxY;
        Debug.Log("변경");
    }

    private void OnTriggerExit2D() 
    {
        currentTeleporter = null;
        Debug.Log("Exit : null");
    }

}
