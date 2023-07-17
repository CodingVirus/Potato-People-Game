using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileJoystickHandler : MonoBehaviour
{
    private bool isClicked = false;

    private GameObject player;
    public Slider sld;
    public GameObject item;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    public void OnInteractionButtonDown()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
     }

    public void OnInteractionButtonUp()
    {
        isClicked = false;
        this.transform.GetChild(0).gameObject.SetActive(false);
        sld.value = 0f;

    }
    void Update()
    {
        //sld.value += Time.deltaTime;
        //if (sld.value == sld.maxValue)
        //{
        //    Inventory inven = player.GetComponent<Inventory>();
        //    for (int i = 0; i < inven.slots.Count; i++)
        //    {
        //        if (inven.slots[i].isEmpty)
        //        {
        //            Instantiate(item, inven.slots[i].slotObj.transform, false);
        //            inven.slots[i].isEmpty = false;
        //            sld.value = 0f;
        //            break;
        //        }
        //    }
        //    this.GetComponent<BoxCollider2D>().enabled = false;
        //    this.transform.GetChild(0).gameObject.SetActive(false);
        //}
    }
}
