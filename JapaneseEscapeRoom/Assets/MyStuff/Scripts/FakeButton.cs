using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FakeButton : MonoBehaviour
{
    public Text faceText;
    public ButtonEvents button;


    // Start is called before the first frame update
    void Start()
    {
        if (button != null) {
            button.onButtonUp += Batsu;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Batsu() {
        faceText.text = "X";
    }
}
