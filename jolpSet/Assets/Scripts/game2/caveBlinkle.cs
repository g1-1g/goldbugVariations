using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveBlinkle : MonoBehaviour
{
    Light Lt;
    int changeSpeed = 40;
    float currentIntensity;
    bool increasing;
    void Start()
    {
        Lt = GetComponent<Light>();
        Lt.intensity = 0;
        currentIntensity = Lt.intensity;
        increasing = true;
    }

    void Update()
    {

        if (increasing)
        {
            if (currentIntensity <= 1)
            {
                currentIntensity += changeSpeed*0.01f * Time.deltaTime;

            }
            else
            {
                increasing = false;
                
            }
        }
        else
        {
            if (currentIntensity >= 0.2)
            {
                currentIntensity -= changeSpeed*0.01f * Time.deltaTime;
            }
            else
            {
                increasing = true;
                
            }
        }
        Lt.intensity = currentIntensity;


    }
}
