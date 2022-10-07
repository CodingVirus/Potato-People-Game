using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    public GameObject gameData;
    List<bool> checkGass = new List<bool>();

    public void GearGass()
    {
        checkGass.Add(true);
        
        //if (checkGass[0] == false || checkGass[1] == false)
        //{
        //    checkGass.Add(true);
        //}
        
    }
}
