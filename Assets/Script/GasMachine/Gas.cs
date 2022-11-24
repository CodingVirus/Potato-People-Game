using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    public GameObject gameData;
    public GameObject dialogueData;
    int count = 0;

    public void GearGass()
    {
        ++count;
        dialogueData.GetComponent<UseItem>().UseItemDialogue("Gas(Clone)");
        if (count == 2)
        {
            gameData.GetComponent<GameDataControl>().gasMachineState = true;
        }
        //if (checkGass[0] == false || checkGass[1] == false)
        //{
        //    checkGass.Add(true);
        //}
        
    }
}
