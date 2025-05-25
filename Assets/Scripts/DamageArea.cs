using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private IHitable hitter;

    public Weapon Weapon;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IDamageable>() is IDamageable damageable)
        {
            damageable.GetDamage(Weapon.Damage);
        }
    }

    public void OnEnable()
    {
        print("Enabled");
    }
    
    private PersonType CheckNearPerson(GameObject person)
    {
        var nearPerson = PersonType.None;
        Enum.TryParse(person.tag.ToString(), out nearPerson);
        
        return nearPerson;
    }
}
