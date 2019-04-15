using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cage : MonoBehaviour
{
    Animator animator;
    int open_hash;
    public AreaTrigger rightKey;
    public AreaTrigger wrongKey;

    public Animator wrongText;
    int fade_hash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        open_hash = Animator.StringToHash("isOpen");

        if (rightKey)
            rightKey.triggerEvent += Open;

        if (wrongKey)
            wrongKey.triggerEvent += WrongKey;

        if (wrongText) {
            fade_hash = Animator.StringToHash("FadeIn");
        }


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

        Destroy(rightKey.gameObject);
    }

    void WrongKey() {
        if (wrongText != null)
            StartCoroutine("SayWrong");
    }

    IEnumerator SayWrong() {
        float showTime = 5f;
        float timer = 0f;

        wrongText.SetBool(fade_hash, true);
        while (timer < showTime) {
            timer += Time.deltaTime;

            yield return null;
        }
        wrongText.SetBool(fade_hash, false);
    }

}
