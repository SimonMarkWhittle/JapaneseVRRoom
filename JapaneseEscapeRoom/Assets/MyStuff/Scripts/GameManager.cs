using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<EventTrigger> events;

    int states = 0;
    int statesAchieved = 0;
    bool won = false;

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
    }

    void Update()
    {
        if (!won && statesAchieved >= states) {
            Debug.Log("YAY! You win!");
            won = true;
        }
    }

    public void AddEvent(EventTrigger _event) {
        _event.achieveEvent += StateAchieved;
        _event.eventCancel += StateCanceled;
        states += 1;
    }

    void StateAchieved() {
        statesAchieved++;

        AchieveText();

        Debug.Log("よかった");
    }

    void StateCanceled() {
        statesAchieved--;
    }

    void AchieveText() {
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

    public static void SwapGroup()
    {
        if (activeGroup == Group.Group1)
            activeGroup = Group.Group2;
        else if (activeGroup == Group.Group2)
            activeGroup = Group.Group1;
    }
}
