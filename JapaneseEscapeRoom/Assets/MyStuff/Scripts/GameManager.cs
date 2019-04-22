using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    List<EventTrigger> events;

    int states = 0;

    int bothStates = 0;

    int group1States = 0;
    int group2States = 0;

    int statesAchieved = 0;
    bool won = false;

    AudioSource source;

    public bool alwaysText = false;

    public static Group activeGroup = Group.Group1;

    public Animator achieveTextAnimator;

    private static GameManager _instance;
    public static GameManager instance {
        get {
            if ( _instance == null ) {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    int fade_hash;

    private void Start() {
        if (achieveTextAnimator != null) {
            fade_hash = Animator.StringToHash("FadeIn");
        }

        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!won && statesAchieved >= states) {
            Debug.Log("YAY! You win!");
            WinText();
            won = true;
        }
    }

    public void AddEvent(EventTrigger _event) {
        _event.achieveEvent += StateAchieved;
        _event.eventCancel += StateCanceled;

        if (_event.group == Group.Both) {
            bothStates++;
        } else if (_event.group == Group.Group1) {
            group1States++;
        } else if (_event.group == Group.Group2) {
            group2States++;
        }
        SetStates();
    }

    void StateAchieved() {
        statesAchieved++;

        source.Play();

        Debug.Log("よかった");
    }

    void StateCanceled() {
        statesAchieved--;
    }

    void WinText() {
        if (achieveTextAnimator != null) {
            StartCoroutine("ShowAchieveText");
        }
    }

    IEnumerator ShowAchieveText() {
        float showTime = 5f;
        float timer = 0f;

        achieveTextAnimator.SetBool(fade_hash, true);
        while (timer < showTime) {
            timer += Time.deltaTime;

            yield return null;
        }
        achieveTextAnimator.SetBool(fade_hash, false);
    }

    public static bool CheckGroup(Group _group)
    {
        return (_group == Group.Both) || (_group == activeGroup);
    }

    public void SwapGroup()
    {
        if (activeGroup == Group.Group1) {
            activeGroup = Group.Group2;

        } else if (activeGroup == Group.Group2) {
            activeGroup = Group.Group1;
        }
        SetStates();
    }

    void SetStates() {
        if (activeGroup == Group.Group1) {
            states = group2States + bothStates;

        } else if (activeGroup == Group.Group2) {
            states = group1States + bothStates;
        }
    }
}
