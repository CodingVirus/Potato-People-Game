using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject currentTeleporter;
    public GameObject fadeEffect;
    public GameObject mon;
    
    public bool transferStart = false;
    public bool transferState = false;

    public Vector3 p_Teleport;

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
            if (inven.slots[i].isEmpty == false && inven.slots[i].slotObj.transform.GetChild(0).name == "CardKey(Clone)")
            {
                key = true;
            }
        }
    }
    private void Awake() 
    {
        theCamera = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerStay2D(Collider2D other)
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
                    //Debug.Log("이동");
                }
            }
            else
            {
                currentTeleporter = other.gameObject;
                transferStart = false;
                Invoke("DoorEnter", 0.5f);
                //Debug.Log("이동");
            }
        }
    }

    public void DoorEnter() 
    {
        if(currentTeleporter == null)
        {
            transferStart = false;
            //Debug.Log("Moving : 이동 false");
        }
        else
        {
            //if(mon.GetComponent<MonsterMove>().traceState == true) mon.GetComponent<MonsterMove>().MonStop();
            Invoke("Fade", 0.5f);
        }
    }

    private void Fade()
    {
        if(currentTeleporter != null)
        {
            transferState = true;
            //currentTeleporter.GetComponent<AudioSource>().Play();
            PlayerMouseControll.instance.StopMove();
            fadeEffect.GetComponent<FadeScript>().Fade();
            //Debug.Log("fade");
            //currentTeleporter.GetComponent<AudioSource>().Play();
            Invoke("Moving", 1.0f);
        }
    }

    private void Moving()
    {
        //Debug.Log("moving 시작");
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        this.GetComponent<PlayerMouseControll>().target = transform.position;
        p_Teleport = transform.position;
        CameraMove();
        PlayerMouseControll.instance.StartMove();
        transferStart = false;
        transferState = false;
        currentTeleporter = null;
        //mon.GetComponent<MonsterMove>().traceSpeed = 4.5f;
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
        //Debug.Log("Exit : null");
    }

    public void DoctorTalkAndMove()
    {
        Moving();
    }

    public void SceneTeleport()
    {
        transform.position = new Vector2(-16.3f, -82.61f);
        theCamera.limitMinX = -27.5f;
        theCamera.limitMaxX = -0.5f;
        theCamera.limitMinY = -83.5f;
        theCamera.limitMaxY = -72.5f;
    }

}
