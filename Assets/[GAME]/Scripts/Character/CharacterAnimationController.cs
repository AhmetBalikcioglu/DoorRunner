using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    Character character;
    Character Character { get { return (character == null) ? character = GetComponentInParent<Character>() : character; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelStart.AddListener(() => InvokeTrigger("Run"));
        //EventManager.OnLevelFinish.AddListener(() => Animator.Rebind());
        EventManager.OnLevelFinish.AddListener(GameEnd);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        
        EventManager.OnLevelStart.RemoveListener(() => InvokeTrigger("Run"));
        //EventManager.OnLevelFinish.RemoveListener(() => Animator.Rebind());
        EventManager.OnLevelFinish.RemoveListener(GameEnd);

    }

    public void InvokeTrigger(string value)
    {
        Animator.SetTrigger(value);
    }

    public void GameEnd()
    {
        if (Character.Won)
            InvokeTrigger("Dance");
        else
            InvokeTrigger("Fall");
    }

}