using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public GameObject slotPanel;
    public List<SlotDataTest> slots = new List<SlotDataTest>();
    private int maxSlot = 3;
    public GameObject slotPrefab;

    private void Start()
    {
        for (int i = 0; i < maxSlot; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            SlotDataTest slot = new SlotDataTest();
            slot.isEmpty = true;
            slot.slotObj = go;
            slots.Add(slot);
        }
    }

    public void InvenCheck()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].isEmpty)
            {

            }
        }
    }
}
