using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{

    public Transform follow;

    void Update()
    {
        if (follow != null)
            transform.position = follow.position;
    }
}
