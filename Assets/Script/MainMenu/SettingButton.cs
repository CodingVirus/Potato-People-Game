using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{

    public GameObject SettingMenu;
    public bool state = false;

    void Start()
    {

    }

    void Update()
    {

    }

    public void settingMenu()
    {
        state = true;
        SettingMenu.SetActive(state);
    }
    public void settingMenuExit()
    {
        
        SettingMenu.SetActive(state);
    }
}
