using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, IItem
{
    [SerializeField] private float healValue;
    
    public void OnTake(Player player)
    {
        player.Heal(healValue);
    }
}
