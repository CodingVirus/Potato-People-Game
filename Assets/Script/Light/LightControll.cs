using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightControll : MonoBehaviour
{
    float time;

    public Light2D global;
    public Light2D test1;
    public Light2D test2;

    public GameObject allB3;
    public GameObject allB2;
    public GameObject allB1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            test1.GetComponent<LightProduction>().enabled = true;
            test2.GetComponent<LightProduction>().enabled = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            test1.GetComponent<LightProduction>().enabled = false;
            test2.GetComponent<LightProduction>().enabled = false;

        }
    }
}
