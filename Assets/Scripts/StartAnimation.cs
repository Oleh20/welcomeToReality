using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAboutTheGame : MonoBehaviour
{
    public Animator animator;
    public AnimationClip animationClip;

    public void PlayAnimationOnClick()
    {

        animator.Play(animationClip.name);
    }
}
