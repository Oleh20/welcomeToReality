using UnityEngine;

public class AnimationFinalLanguage : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimationOnClick()
    {

        animator.Play("Final language");
    }
}