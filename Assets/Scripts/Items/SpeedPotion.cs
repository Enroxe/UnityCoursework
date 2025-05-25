using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour,IItem
{
    [SerializeField] private float speedValue;
    
    public void OnTake(Player player)
    {
        player.IncreaseSpeed(2);
    }
}
