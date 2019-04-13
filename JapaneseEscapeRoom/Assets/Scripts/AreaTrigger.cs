using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AreaTrigger : EventTrigger
{
    public List<string> tags;

    BoxCollider box;

    protected override void Start() {
        base.Start();

        box = GetComponent<BoxCollider>();
        box.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other) {
        foreach (string tag in tags) {
            if (other.gameObject.CompareTag(tag)) {
                TriggerEvent();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (!reverseable) return;

        foreach (string tag in tags) {
            if (other.gameObject.CompareTag(tag)) {
                EventCancel();
            }
        }
    }
}
