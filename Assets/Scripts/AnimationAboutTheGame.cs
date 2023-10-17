using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAboutTheGame : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimationOnClick()
    {

        animator.Play("Final about the game");
    }
}
