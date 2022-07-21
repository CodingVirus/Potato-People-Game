using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTest : MonoBehaviour
{
    public GameObject slotPanel;
    public List<SlotDataTest> slots = new List<SlotDataTest>();
    private int maxSlot = 4;
    public GameObject slotPrefab;

    private void Start()
    {
        for (int i = 0; i < maxSlot; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            //go.GetComponent<Button>().onClick.AddListener(UseItem);
            SlotDataTest slot = new SlotDataTest();
            slot.isEmpty = true;
            slot.slotObj = go;
            slots.Add(slot);
        }
    }

    //public void UseItem()
    //{
    //    if (this.transform.GetChild(0).name == "Coke")
    //    {
    //        Debug.Log("Use Coke!!!");

    //    }
    //}    
}
