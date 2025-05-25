using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Класс для запуска конца уровня
public class LevelEnder : MonoBehaviour
{
    [SerializeField] LevelMenu levelMenu;
    
    //При соприкосновении с игроком(в этом случае с флагом) - происходит активация меню уровня(конца)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            levelMenu.ActivateLevelMenu();
            Time.timeScale = 0f;
        }
    }
}
