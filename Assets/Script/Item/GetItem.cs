using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    float MaxDistance = 15f;
    Vector3 MousePostion;
    Camera Camera;
    Inventory inven;

    public GameObject ply;
    public GameObject gameData;
    public List<GameObject> ItemList = new List<GameObject>();

    private void Start()
    {
        Camera = GetComponent<Camera>();
        inven = ply.GetComponent<Inventory>();
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
                    Destroy(hit.transform.gameObject);
                    hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                }

                else if (hit.transform.gameObject.name == "Drug Combiner")
                {
                    ply.GetComponent<PlayerMouseControll>().StopMove();
                    hit.transform.GetChild(0).gameObject.SetActive(false);
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

                else if (hit.transform.gameObject.name == "key box (open)")
                {
                    ply.GetComponent<PlayerMouseControll>().StopMove();
                    for (int i = 0; i < inven.slots.Count; i++)
                    {
                        if (inven.slots[i].isEmpty)
                        {
                            Instantiate(ItemList[6], inven.slots[i].slotObj.transform, false);
                            inven.slots[i].isEmpty = false;
                            hit.transform.GetChild(1).gameObject.SetActive(false);
                            break;
                        }
                    }
                    Invoke("PlyMoveStart", 0.5f);
                    hit.transform.GetComponent<SpriteRenderer>().enabled = false;
                    hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                    hit.transform.GetChild(0).transform.gameObject.SetActive(true);
                }

                else if (hit.transform.gameObject.tag == "Ladder")
                {
                    int count = 0;
                    ply.GetComponent<PlayerMouseControll>().StopMove();
                    for (int i = 0; i < inven.slots.Count; i++)
                    {
                        if (inven.slots[i].isEmpty)
                        {
                            Instantiate(ItemList[3], inven.slots[i].slotObj.transform, false);
                            inven.slots[i].isEmpty = false;
                            break;
                        }

                        else
                            count++;
                    }

                    if (count >= inven.slots.Count)
                    {
                        Debug.Log("Pull!!!");
                        Invoke("PlyMoveStart", 0.5f);
                    }

                    else
                    {
                        Invoke("PlyMoveStart", 0.5f);
                        //hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                        hit.transform.gameObject.SetActive(false);
                    }
                }

                else if (hit.transform.gameObject.tag == "ClueyKey")
                {
                    if (hit.transform.GetChild(0).gameObject.activeSelf == true)
                    {
                        ply.GetComponent<PlayerMouseControll>().StopMove();
                        
                        for (int i = 0; i < inven.slots.Count; i++)
                        {
                            if (inven.slots[i].isEmpty)
                            {
                                Instantiate(ItemList[1], inven.slots[i].slotObj.transform, false);
                                inven.slots[i].isEmpty = false;
                                hit.transform.GetChild(1).gameObject.SetActive(false);
                                break;
                            }
                        }
                        Invoke("PlyMoveStart", 0.2f);
                        hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                    }
                }

                else if (hit.transform.gameObject.name == "box 2_1")
                {
                    ply.GetComponent<PlayerMouseControll>().StopMove();
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

                else if (hit.transform.gameObject.name == "casket 1_2")
                {
                    ply.GetComponent<PlayerMouseControll>().StopMove();
                    for (int i = 0; i < inven.slots.Count; i++)
                    {
                        if (inven.slots[i].isEmpty)
                        {
                            Instantiate(ItemList[5], inven.slots[i].slotObj.transform, false);
                            inven.slots[i].isEmpty = false;
                            break;
                        }
                    }
                    Invoke("PlyMoveStart", 0.5f);
                    hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                }
                
                else if (hit.transform.gameObject.name == "drawer 1")
                {
                    //ply.GetComponent<PlayerMouseControll>().StopMove();
                    //Inventory inven = ply.GetComponent<Inventory>();
                    //for (int i = 0; i < inven.slots.Count; i++)
                    //{
                    //    if (inven.slots[i].isEmpty)
                    //    {
                    //        Instantiate(ItemList[6], inven.slots[i].slotObj.transform, false);
                    //        inven.slots[i].isEmpty = false;
                    //        break;
                    //    }
                    //}
                    //Invoke("PlyMoveStart", 0.5f);
                    //hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                }

                else if (hit.transform.gameObject.name == "drawer 2")
                {
                    ply.GetComponent<PlayerMouseControll>().StopMove();
                    for (int i = 0; i < inven.slots.Count; i++)
                    {
                        if (inven.slots[i].isEmpty)
                        {
                            Instantiate(ItemList[7], inven.slots[i].slotObj.transform, false);
                            inven.slots[i].isEmpty = false;
                            break;
                        }
                    }
                    Invoke("PlyMoveStart", 0.5f);
                    hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                }

                else if (hit.transform.gameObject.tag == "Gas")
                {
                    ply.GetComponent<PlayerMouseControll>().StopMove();
                    for (int i = 0; i < inven.slots.Count; i++)
                    {
                        if (inven.slots[i].isEmpty)
                        {
                            Instantiate(ItemList[8], inven.slots[i].slotObj.transform, false);
                            inven.slots[i].isEmpty = false;
                            break;
                        }
                    }
                    Invoke("PlyMoveStart", 0.5f);
                    //hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                    Destroy(hit.transform.gameObject);
                }


            }
        }
    }

    public void PlyMoveStart()
    {
        gameData.GetComponent<GameDataControl>().PlayerMouseControllOn();
        ply.GetComponent<PlayerMouseControll>().MaintainPosition();
        ply.GetComponent<PlayerMouseControll>().StartMove();
    }

}
