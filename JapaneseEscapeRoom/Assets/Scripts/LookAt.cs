using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LookAt : MonoBehaviour
{
    Transform target;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        target = player.hmdTransform;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target.transform);
        transform.LookAt(2 * transform.position - target.position);
    }
}
