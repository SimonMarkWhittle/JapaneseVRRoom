using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventDel();

public enum Group { Group1, Group2 };

public class EventTrigger : MonoBehaviour
{
    public EventDel triggerEvent;
    public EventDel eventCancel;

    public Group group = Group.Group1;

    public bool isAchievement = true;
    public bool onlyOnce = true;
    protected bool doneOnce = false;
    public bool reverseable = false;

    protected virtual void Start() {
        GameManager gm = GameManager.instance;
        if (isAchievement && GameManager.CheckGroup(group))
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
