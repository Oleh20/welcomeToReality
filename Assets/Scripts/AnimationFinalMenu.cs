using UnityEngine;

public class AnimationFinalMenu : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimationOnClick()
    {

        animator.Play("Final menu");
    }
}