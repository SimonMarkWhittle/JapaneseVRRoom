using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    public List<GameObject> fires;

    AreaTrigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject fire in fires) {
            fire.SetActive(false);
        }

        trigger = GetComponentInChildren<AreaTrigger>();

        if (trigger != null)
            trigger.triggerEvent += GetLit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetLit() {
        Debug.Log("Get Lit Fam");
        foreach (GameObject fire in fires) {
            fire.SetActive(true);
        }
    }
}
