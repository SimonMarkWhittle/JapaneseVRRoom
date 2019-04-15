using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    Animator animator;
    int open_hash;
    AreaTrigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        open_hash = Animator.StringToHash("isOpen");

        trigger = GetComponentInChildren<AreaTrigger>();

        trigger.triggerEvent += Open;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Open() {
        Debug.Log("Doing Open");
        if (animator != null) {
            Debug.Log("setting bool");
            animator.SetBool(open_hash, true);
        }

        Destroy(trigger.gameObject);
    }
}
