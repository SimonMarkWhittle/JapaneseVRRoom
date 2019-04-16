using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseFall : EventTrigger
{

    protected override void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.2f) {
            TriggerEvent();
        }
    }
}
