using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupChoose : MonoBehaviour
{
    ButtonEvents theButton;

    Text theText;

    // Start is called before the first frame update
    void Start()
    {
        theButton = GetComponentInChildren<ButtonEvents>();

        if (theButton != null)
            theButton.onButtonDown += Swappa;

        theText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Swappa()
    {
        GameManager.instance.SwapGroup();

        if (theText)
        {
            theText.text = GameManager.activeGroup.ToString();
        }
    }
}
