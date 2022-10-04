using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    float MaxDistance = 15f;
    Vector3 MousePostion;
    Camera Camera;
    public GameObject ply;
    public List<GameObject> ItemList = new List<GameObject>();

    private void Start()
    {
        Camera = GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePostion = Input.mousePosition;
            MousePostion = Camera.ScreenToWorldPoint(MousePostion);

            RaycastHit2D hit = Physics2D.Raycast(MousePostion, transform.forward, MaxDistance);
            if (hit)
            {
                if (hit.transform.gameObject.tag == "Item")
                {
                    ply.GetComponent<PlayerMouseControll>().StopMove();
                    Inventory inven = ply.GetComponent<Inventory>();
                    for (int i = 0; i < inven.slots.Count; i++)
                    {
                        if (inven.slots[i].isEmpty)
                        {
                            Instantiate(ItemList[0], inven.slots[i].slotObj.transform, false);
                            inven.slots[i].isEmpty = false;
                            break;
                        }
                    }
                    Invoke("PlyMoveStart", 0.5f);
                    hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                }

                else if (hit.transform.gameObject.tag == "Ladder")
                {
                    ply.GetComponent<PlayerMouseControll>().StopMove();
                    Inventory inven = ply.GetComponent<Inventory>();
                    for (int i = 0; i < inven.slots.Count; i++)
                    {
                        if (inven.slots[i].isEmpty)
                        {
                            Instantiate(ItemList[3], inven.slots[i].slotObj.transform, false);
                            inven.slots[i].isEmpty = false;
                            break;
                        }
                    }
                    Invoke("PlyMoveStart", 0.5f);
                    //hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                    hit.transform.gameObject.SetActive(false);
                }

                else if (hit.transform.gameObject.tag == "ClueyKey")
                {
                    if (hit.transform.GetChild(0).gameObject.activeSelf == true)
                    {
                        ply.GetComponent<PlayerMouseControll>().StopMove();
                        Inventory inven = ply.GetComponent<Inventory>();
                        for (int i = 0; i < inven.slots.Count; i++)
                        {
                            if (inven.slots[i].isEmpty)
                            {
                                Instantiate(ItemList[1], inven.slots[i].slotObj.transform, false);
                                inven.slots[i].isEmpty = false;
                                break;
                            }
                        }
                        Invoke("PlyMoveStart", 0.5f);
                        hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                    }
                }

                else if (hit.transform.gameObject.name == "desk 2")
                {
                    ply.GetComponent<PlayerMouseControll>().StopMove();
                    Inventory inven = ply.GetComponent<Inventory>();
                    for (int i = 0; i < inven.slots.Count; i++)
                    {
                        if (inven.slots[i].isEmpty)
                        {
                            Instantiate(ItemList[4], inven.slots[i].slotObj.transform, false);
                            inven.slots[i].isEmpty = false;
                            break;
                        }
                    }
                    Invoke("PlyMoveStart", 0.5f);
                    hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }

    public void PlyMoveStart()
    {
        ply.GetComponent<PlayerMouseControll>().MaintainPosition();
        ply.GetComponent<PlayerMouseControll>().StartMove();
    }
}
