using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitController : IHitable
{
    private AnimatorSystem animSystem;
    public DamageArea DamageArea;
        
    public bool IsHit
    {
        get { return animSystem.IsPlaying("attack"); }
    }
    
    public PlayerHitController(AnimatorSystem animSystem,
                                DamageArea damageArea)
    {
        this.DamageArea = damageArea;
        this.animSystem = animSystem;
    }

    public void ThrowHit()
    {
        DamageArea.gameObject.SetActive(true);
    }

    public void StopHit()
    {
        DamageArea.gameObject.SetActive(false);
    }
}
