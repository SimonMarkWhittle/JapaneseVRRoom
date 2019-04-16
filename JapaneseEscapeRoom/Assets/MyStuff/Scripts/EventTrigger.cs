using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventDel();

public class EventTrigger : MonoBehaviour
{
    public EventDel triggerEvent;
    public EventDel eventCancel;

    public bool isAchievement = true;
    public bool onlyOnce = true;
    protected bool doneOnce = false;
    public bool reverseable = false;

    protected virtual void Start() {
        GameManager gm = GameManager.instance;
        if (isAchievement)
            gm.AddEvent(this);
    }

    protected void TriggerEvent() {
        if (onlyOnce && doneOnce) return;
        doneOnce = true;
        triggerEvent?.Invoke();
    }

    protected void EventCancel() {
        doneOnce = false;
        eventCancel?.Invoke();
    }
}
