using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationState
{
    Idle,
    Running
}

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlayAnimation(Animator animator, AnimationState animationState)
    {
        int animState = (int)animationState;
        animator.SetInteger("Player", animState);
    }
}