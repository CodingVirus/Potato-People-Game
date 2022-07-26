using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject currentTeleporter;
    public GameObject fadeEffect;
    public bool transferStart = false;

    public bool key = false;
    
    //public bool T_camera = false;
    private CameraFollow theCamera;

    private void Update()
    {
       // FindItem();
    }
    private void FindItem()
    {
        Inventory inven = this.GetComponent<Inventory>();
        for (int i = 0; i < inven.slots.Count; i++)
        {
            if (inven.slots[i].isEmpty == false && inven.slots[i].slotObj.transform.GetChild(0).name == "Drug(Clone)")
            {
                key = true;
            }
        }
    }
    private void Awake() 
    {
        theCamera = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        FindItem();
        if(transferStart == true)
        {
            if (other.name == "door3_1")
            {
                currentTeleporter = null;
                if (key == true)
                {
                    currentTeleporter = other.gameObject;
                    Invoke("DoorEnter", 0.5f);
                    Debug.Log("이동");
                }
            }
            //if(other.CompareTag("Door"))
            //{
            else
            {
                currentTeleporter = other.gameObject;
                Invoke("DoorEnter", 0.5f);
                Debug.Log("이동");
            }
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
        if(currentTeleporter == null)
        {
            transferStart = false;
            Debug.Log("Moving : 이동 false");
        }
        else
        {
            Invoke("Fade", 0.5f);
        }
    }

    private void Fade()
    {
        if(currentTeleporter != null)
        {
            //currentTeleporter.GetComponent<AudioSource>().Play();
            PlayerMouseControll.instance.StopMove();
            fadeEffect.GetComponent<FadeScript>().Fade();
            Debug.Log("fade");
            //currentTeleporter.GetComponent<AudioSource>().Play();
            Invoke("Moving", 1.0f);
        }
    }

    private void Moving()
    {
        Debug.Log("moving 시작");
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        this.GetComponent<PlayerMouseControll>().target = transform.position;
        CameraMove();
        PlayerMouseControll.instance.StartMove();
        transferStart = false;
        currentTeleporter = null;
        
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
