using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Panel_Attack : MonoBehaviour
{
    public static Action panel, panel_out;
    
    private void Awake() {
        panel = () => {Show();};
        panel_out = () => {Awake();};
        transform.gameObject.SetActive(false);
    }
    public void Show(){
 
        transform.gameObject.SetActive(true); 
        
    }
}
