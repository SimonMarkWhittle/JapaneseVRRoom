using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public List<Light> lights;
    int onIndex = 0;

    public ButtonEvents events;

    void Start()
    {
        events.onButtonDown += LightSwitch;

        for (int i = 0; i < lights.Count; i++) {
            Light light = lights[i];

            if (i == 0)
                light.enabled = true;
            else
                light.enabled = false;
        }
    }

    void LightSwitch()
    {
        Debug.Log("LightSwitch");

        Light activeLight = lights[onIndex];

        // set onIndex to the next light or 0 if at the end of the list
        onIndex = ++onIndex % lights.Count; 

        Light nextLight = lights[onIndex];

        // set the next light as enabled and current light as disabled
        activeLight.enabled = false;
        nextLight.enabled = true;
    }
}
