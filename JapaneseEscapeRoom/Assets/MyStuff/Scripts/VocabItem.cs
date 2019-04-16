using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class VocabItem : MonoBehaviour
{
    public Animator animator;
    int fade_hash;

    AudioSource source;

    public List<TextMeshPro> texts;

    // Start is called before the first frame update
    void Start()
    {
        //SetText(false);
        if (animator == null)
            animator = GetComponentInChildren<Animator>();
        fade_hash = Animator.StringToHash("FadeIn");
        source = GetComponent<AudioSource>();
    }

    public void StartDisplay()
    {
        //SetText(true);
        animator.SetBool(fade_hash, true);
        // source.Play();
        //ReadText();
    }

    public void EndDisplay()
    {
        animator.SetBool(fade_hash, false);
        //SetText(false);
    }

    public void SetText(bool state)
    {
        if (texts != null)
        {
            foreach (TextMeshPro text in texts)
            {
                text.enabled = state;
            }
        }
    }

    public void ReadText() {
    }
}
