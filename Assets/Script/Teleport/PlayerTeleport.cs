using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject currentTeleporter;
    public GameObject fadeEffect;
    public GameObject gameData;
    public GameObject dialogueData;
    
    public bool transferStart = false;
    public bool transferState = false;
    public bool next = true;

    public Vector3 p_Teleport;

    public bool key = false;
    
    //public bool T_camera = false;
    private CameraFollow theCamera;

    private void FindItem()
    {
        Inventory inven = this.GetComponent<Inventory>();
        for (int i = 0; i < inven.slots.Count; i++)
        {
            if (inven.slots[i].isEmpty == false && inven.slots[i].slotObj.transform.GetChild(0).name == "Key(Clone)")
            {
                key = true;
            }
        }
    }
    public void UseKey()
    {
        
    }
    private void Awake() 
    {
        theCamera = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(transferStart == true)
        {
            if (other.name == "door3_1")
            {
                FindItem();
                currentTeleporter = null;
                if (key == true)
                {
                    currentTeleporter = other.gameObject;
                    Invoke("DoorEnter", 0.5f);

                    gameData.GetComponent<GameDataControl>().prisonDoor = true;
                    dialogueData.GetComponent<UseItem>().UseItemDialogue("Key(Clone)");
                    other.transform.GetChild(1).position += new Vector3(-2, 0, 0);
                    other.name = "door3_1_open";
                    
                    transferStart = false;
                    //Debug.Log("이동");
                }
            }

            else if (other.name == "door2_1")
            {
                currentTeleporter = null;
                Inventory inven = this.GetComponent<Inventory>();
                if (inven.FindItem("CardKeyA1(Clone)") == true)
                {
                    currentTeleporter = other.gameObject;
                    Invoke("DoorEnter", 0.5f);
                    transferStart = false;
                }
            }

            else if (other.name == "door2_2")
            {
                currentTeleporter = null;
                if (key == true)
                {
                    currentTeleporter = other.gameObject;
                    Invoke("DoorEnter", 0.5f);
                    gameData.GetComponent<GameDataControl>().prisonDoor = true;
                    transferStart = false;
                    //Debug.Log("이동");
                }
            }

            else if (other.name == "Upstairs_B3")
            {
                currentTeleporter = null;
                if (gameData.GetComponent<GameDataControl>().b3Door == true)
                {
                    currentTeleporter = other.gameObject;
                    Invoke("DoorEnter", 0.5f);
                    transferStart = false;
                }
            }
            
            else if (other.name == "door3_3")
            {
                currentTeleporter = null;
                if (gameData.GetComponent<GameDataControl>().password == true)
                {
                    currentTeleporter = other.gameObject;
                    Invoke("DoorEnter", 0.5f);
                    transferStart = false;
                }
            }

            else if (other.name == "door3_4")
            {
                currentTeleporter = null;
                if (gameData.GetComponent<GameDataControl>().clueyQuest == true)
                {
                    currentTeleporter = other.gameObject;
                    Invoke("DoorEnter", 0.5f);
                    transferStart = false;
                }
            }

            else if (other.name == "door1_1")
            {
                currentTeleporter = null;
                Inventory inven = this.GetComponent<Inventory>();
                if (inven.FindItem("OfficeKey(Clone)") == true)
                {
                    currentTeleporter = other.gameObject;
                    Invoke("DoorEnter", 0.5f);
                    gameData.GetComponent<GameDataControl>().officeDoor = true;
                    dialogueData.GetComponent<UseItem>().UseItemDialogue("OfficeKey(Clone)");
                    other.name = "door1_1_open";
                    transferStart = false;
                }
            }

            else if (other.name == "Upstairs_B1")
            {
                currentTeleporter = null;
                Inventory inven = this.GetComponent<Inventory>();
                if (inven.FindItem("FinalCardKey(Clone)") == true)
                {
                    currentTeleporter = other.gameObject;
                    Invoke("DoorEnter", 0.5f);
                    gameData.GetComponent<GameDataControl>().b1Door = true;
                    transferStart = false;
                }
            }

            else
            {
                currentTeleporter = other.gameObject;
                Invoke("DoorEnter", 0.5f);
                transferStart = false;
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
        next = false;
        
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

