using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBox : MonoBehaviour
{

    public ButtonEvents button;

    Animator animator;
    int isOpen_hash;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isOpen_hash = Animator.StringToHash("isOpen");

        if (button != null) {
            button.onButtonUp += Open;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Open() {
        animator.SetBool(isOpen_hash, true);
    }
}
