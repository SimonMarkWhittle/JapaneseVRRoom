using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FakeButton : MonoBehaviour
{
    public TextMeshPro textMesh;
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
        textMesh.text = "X";
    }
}
