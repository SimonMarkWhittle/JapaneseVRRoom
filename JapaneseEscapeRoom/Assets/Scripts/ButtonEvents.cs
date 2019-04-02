﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EventDel();

public class ButtonEvents : MonoBehaviour
{

    public EventDel onButtonDown;
    public EventDel onButtonUp;

    public void OnButtonDown()
    {
        onButtonDown?.Invoke();
    }

    public void OnButtonUp()
    {
        onButtonUp?.Invoke();
    }
}