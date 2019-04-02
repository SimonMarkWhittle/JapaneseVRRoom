using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class EventsOrSomething : MonoBehaviour
{
    public ButtonEvents daButton;

    private void Start()
    {
        daButton.onButtonDown += DoIt;
        daButton.onButtonUp += DidIt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoIt()
    {
        Debug.Log("It DID");
    }

    void DidIt()
    {
        Debug.Log("DID TI");
    }
}
