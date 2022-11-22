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
    public Vector3 targetPoint;
    private Vector3 transPosition;
    private Vector3 mouse;
    private Vector3 transPos;
    private Vector3 target;
    private Vector3 mousePos;
    public string n;

    public bool key = false;
    public bool door3 = false;
    
    private CameraFollow theCamera;

    private void Awake() 
    {
        theCamera = Camera.main.GetComponent<CameraFollow>();
    }

    private void FixedUpdate() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                n = hit.collider.name;
                //Debug.Log(n);
                // if(transferStart == true)
                // {
                //     Invoke("Fade", 0.5f);
                // }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        FindItem();
            if (other.name == "door3_1")
            {
                currentTeleporter = null;
                if (key == true)
                {
                    currentTeleporter = other.gameObject;
                    transferStart = false;
                    door3 = true;
                    Invoke("Moving", 0.5f);
                }
            }
            if(other.name == n)
            {
                currentTeleporter = other.gameObject;
                transferStart = true;
                Invoke("Moving", 1.0f);
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
            Invoke("Moving", 1.2f);
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
        //currentTeleporter = null;
    }

    private void CameraMove()
    {
        theCamera.limitMinX = currentTeleporter.GetComponent<Teleporter>().T_limitMinX;
        theCamera.limitMaxX = currentTeleporter.GetComponent<Teleporter>().T_limitMaxX;
        theCamera.limitMinY = currentTeleporter.GetComponent<Teleporter>().T_limitMinY;
        theCamera.limitMaxY = currentTeleporter.GetComponent<Teleporter>().T_limitMaxY;
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

    private void OnTriggerExit2D() 
    {
        currentTeleporter = null;
    }

    public void DoctorTalkAndMove()
    {
        Moving();
    }

    // public void SceneTeleport()
    // {
    //     transform.position = new Vector2(-16.3f, -82.61f);
    //     theCamera.limitMinX = -27.5f;
    //     theCamera.limitMaxX = -0.5f;
    //     theCamera.limitMinY = -83.5f;
    //     theCamera.limitMaxY = -72.5f;
    // }

}
