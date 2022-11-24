using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightProduction : MonoBehaviour
{
    private Light2D theLight;
    private float targetIntensity;
    private float currentIntensity;
    public float setIntensity = 0.3f;

    // Start is called before the first frame update
    void Start()
    {

        theLight = GetComponent<Light2D>();
        currentIntensity = theLight.intensity;
        targetIntensity = Random.Range(setIntensity, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(targetIntensity - currentIntensity) >= 0.01)
        {
            if (targetIntensity - currentIntensity >= 0)
            {
                currentIntensity += Time.deltaTime * 3f;
            }
            else
            {
                currentIntensity -= Time.deltaTime * 3f;
            }
            theLight.intensity = currentIntensity;
            //theLight.range = currentIntensity + 10;
            //theLight.falloffIntensity = currentIntensity + 5;
            
        }
        else
        {
            targetIntensity = Random.Range(setIntensity, 1f);
        }
    }
}
