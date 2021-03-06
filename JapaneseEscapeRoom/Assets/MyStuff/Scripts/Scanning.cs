﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
using Valve.VR.Extras;

//[RequireComponent(typeof(SteamVR_LaserPointer))]
public class Scanning : MonoBehaviour
{
    public SteamVR_Action_Boolean scanAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Scan");

    private Hand pointerHand = null;
    private Player player = null;

    private bool visible = true;

    private SteamVR_LaserPointer pointer;

    public bool allowScanWhileAttached = false;

    private VocabItem lastVocab = null;

    //private bool scanning = false;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;

        if (player == null)
        {
            Debug.LogError("<b>[SteamVR Interaction]</b> Teleport: No Player instance found in map.");
            Destroy(this.gameObject);
            return;
        }

        //pointer = GetComponent<SteamVR_LaserPointer>();
        //pointer.color = Color.clear;
        //pointer.pointer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Hand hand in player.hands)
        {
            if (IsScanButtonDown(hand))
            {
                //scanning = true;
                Scan(hand);
            }
            else if (IsEligibleForScan(hand)) {
                pointer = hand.gameObject.GetComponent<SteamVR_LaserPointer>();
                pointer.pointer.SetActive(false);
                if (lastVocab != null)
                {
                    lastVocab.EndDisplay();
                    lastVocab = null;
                }
            }
        }
    }

    void Scan(Hand hand)
    {
        pointer = hand.gameObject.GetComponent<SteamVR_LaserPointer>();
        Transform hTransform = hand.transform;
        RaycastHit hit;

        if (Physics.Raycast(hTransform.position, hTransform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(hTransform.position, hTransform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Vector3 pos1 = hTransform.position;
            Vector3 pos2 = hTransform.TransformDirection(Vector3.forward) * hit.distance;

            //pointer.active = true;
            pointer.pointer.SetActive(true);
            pointer.color = Color.blue;

            //VocabItem vocab = hit.collider.GetComponent<VocabItem>();
            VocabItem vocab = hit.collider.GetComponentInChildren<VocabItem>();


            if (vocab != null) {
                vocab.StartDisplay();
            }
            if (vocab != lastVocab && lastVocab != null)
            {
                lastVocab.EndDisplay();
                lastVocab = vocab;
            } else
            {
                lastVocab = vocab;
            }
        }
        else
        {
            Debug.DrawRay(hTransform.position, hTransform.TransformDirection(Vector3.forward) * 1000f, Color.white);

            Vector3 pos1 = hTransform.position;
            Vector3 pos2 = hTransform.TransformDirection(Vector3.forward) * 1000f;

            pointer.color = Color.white;
            if (lastVocab != null)
            {
                lastVocab.EndDisplay();
                lastVocab = null;
            }
        }
    }


    bool WasScanButtonPressed(Hand hand)
    {
        Debug.Log("elligible for scan:" + IsEligibleForScan(hand).ToString());
        if (IsEligibleForScan(hand))
        {
            if (hand.noSteamVRFallbackCamera != null)
            {
                return Input.GetKeyDown(KeyCode.S);
            }
            else
            {
                return scanAction.GetStateDown(hand.handType);
            }
        }

        return false;
    }

    bool WasScanButtonReleased(Hand hand)
    {
        if ( IsEligibleForScan( hand ) )
        {
            if ( hand.noSteamVRFallbackCamera != null )
            {
                return Input.GetKeyUp( KeyCode.S );
            }
            else
            {
                return scanAction.GetStateUp(hand.handType);
            }
        }

        return false;
    }

    bool IsScanButtonDown(Hand hand)
    {
        if (IsEligibleForScan(hand))
        {
            if (hand.noSteamVRFallbackCamera != null)
            {
                return Input.GetKey(KeyCode.S);
            }
            else
            {
                return scanAction.GetState(hand.handType);
            }
        }

        return false;
    }

    public bool IsEligibleForScan( Hand hand )
    {
        if ( hand == null)
        {
            return false;
        }

        if ( !hand.gameObject.activeInHierarchy )
        {
            return false;
        }

        if (hand.hoveringInteractable != null)
        {
            return false;
        }

        if ( hand.noSteamVRFallbackCamera == null )
        {
            if (hand.isActive == false)
            {
                return false;
            }

            if (hand.currentAttachedObject != null)
            {
                return false;
            }
        }

        if ( hand.gameObject.GetComponent<SteamVR_LaserPointer>() == null )
        {
            return false;
        }

        return true;
    }
}
