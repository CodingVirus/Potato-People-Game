using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private bool isClicked = false;

    public GameObject ply;
    public Slider sld;
    public GameObject item;

    public void OnMouseDown()
    {
        isClicked = true;
        this.transform.GetChild(0).gameObject.SetActive(true);
        ply.GetComponent<PlayerMouseControll>().StopMove();
    }

    public void OnMouseUp()
    {
        isClicked = false;
        this.transform.GetChild(0).gameObject.SetActive(false);
        ply.GetComponent<PlayerMouseControll>().StartMove();
        ply.GetComponent<PlayerMouseControll>().MaintainPosition();

        sld.value = 0f;

    }

    void Update()
    {
        if (isClicked)
        {
            sld.value += Time.deltaTime;
            if (sld.value == sld.maxValue)
            {
                Inventory inven = ply.GetComponent<Inventory>();
                for (int i = 0; i < inven.slots.Count; i++)
                {
                    if (inven.slots[i].isEmpty)
                    {
                        Instantiate(item, inven.slots[i].slotObj.transform, false);
                        inven.slots[i].isEmpty = false;
                        sld.value = 0f;
                        break;
                    }
                }
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.transform.GetChild(0).gameObject.SetActive(false);
                //OnMouseUp();
            }
        }
    }
}
