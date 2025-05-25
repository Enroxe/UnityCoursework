using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Класс для контроля нанесения урона
//Не является MonoBehaviour для упрощения и уменьшения компонентов в инспекторе
//Методы вызываются в Enemy
public class EnemyHitController : IHitable
{
    private DamageArea damageArea;

    private AnimatorSystem animSys;
    
    public EnemyHitController(AnimatorSystem animSys, DamageArea damageArea)
    {
        this.animSys = animSys;
        this.damageArea = damageArea;
    }

    public void ThrowHit()
    {
        damageArea.gameObject.SetActive(true);
    }
    
    public void StopHit()
    {
        damageArea.gameObject.SetActive(false);
    }
    
    public bool IsHit
    {
        get { return animSys.IsPlaying("attack"); }
    }
}
