using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSystem
{
    Animator animator;
    
    public Dictionary<string, float> durations = new Dictionary<string, float>();
    
    public AnimatorSystem(Animator animator)
    {
        this.animator = animator;

        foreach (var clip in animator.runtimeAnimatorController.animationClips)
        {
            durations.Add(clip.name, clip.length);
        }
    }

    //Текущая анимация
    public bool IsPlaying(string animationName)
    {
        if (animator == null) return false;
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime > 0f;
    }
    
    public void Idle(bool state)
    {
        animator.SetBool("IsWalking", state);
    }

    public float Walk(bool state)
    {
        animator.SetBool("IsWalking", state);
        return animator.GetCurrentAnimatorStateInfo(0).length;
    }

    public float Attack(bool state)
    {
        animator.SetBool("IsAttacking", state);
        return animator.GetCurrentAnimatorStateInfo(0).length;
    }

    public float Hurt(bool state)
    {
        animator.Play("Base Layer.hurt", 0, 1f);
        //animator.SetBool("IsHurting", state);
        return animator.GetCurrentAnimatorStateInfo(0).length;
    }

    public void Die(bool state)
    {
        animator.SetBool("IsDying", state);
    }
}
