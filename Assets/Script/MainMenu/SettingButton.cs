using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    public GameObject menu;
    public GameObject SettingMenu;
    private int count = 0;

    private void Start() 
    {
        menu.gameObject.SetActive(true);
    }

    public void GoMenu()
    {
        Debug.Log("열림");
        menu.gameObject.SetActive(true);
        count++;
        if(count == 2)
        {
            menu.gameObject.SetActive(false);
            Debug.Log("닫음");
            count = 0;
        }
    }

    public void GoMain()
    {
        SceneManager.LoadScene(0);
    }

    public void GoSetting()
    {
        
        SettingMenu.SetActive(true);
    }

    public void CloseSetting()
    {
        SettingMenu.SetActive(false);
    }
}
