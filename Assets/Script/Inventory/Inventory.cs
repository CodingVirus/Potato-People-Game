using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class Inventory : MonoBehaviour
{
    public GameObject slotPanel;
    public List<SlotData> slots = new List<SlotData>();
    private int maxSlot = 4;
    public GameObject slotPrefab;

    private void Start()
    {
        for (int i = 0; i < maxSlot; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            go.GetComponent<UseItem>().playerObj = this.gameObject;
            SlotData slot = new SlotData();
            slot.isEmpty = true;
            slot.slotObj = go;
            slots.Add(slot);
        }
    }

    public void AddItem(GameObject item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].isEmpty)
            {
                Instantiate(item, slots[i].slotObj.transform, false);
                slots[i].isEmpty = false;
                break;
            }
        }
    }

    public bool FindItem(string itemName)
    {
        bool checkItem = false;
        for (int i = 0; i < this.slots.Count; i++)
        {
            if (this.slots[i].isEmpty == false && this.slots[i].slotObj.transform.GetChild(0).name == itemName)
            {
                checkItem = true;
            }
        }
        return checkItem;
    }
}
