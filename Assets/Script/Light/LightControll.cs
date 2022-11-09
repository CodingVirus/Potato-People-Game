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
            //Debug.Log(Random.Range(0, 2));
            //test1.intensity = Random.Range(0, 2);
            //test2.intensity = Random.Range(0, 2);
            if (time < 0.5f)
            {
                //allB1.SetActive(false);
                test1.intensity = 0;
                test2.intensity = 0;
            }

            else
            {
                //allB1.SetActive(true);
                test1.intensity = 1;
                test2.intensity = 1;
                if (time > 1f)
                {
                    time = 0;
                }
            }
            time += Time.deltaTime;
        }
    }
}
