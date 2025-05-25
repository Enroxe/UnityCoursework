using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//Главный класс врага
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] EnemyHitController hitController;//Контроллер для нанесения удара
    [SerializeField] EnemyMovement movementController;//Контроллер для передвижения
    [SerializeField] NPCTypeArea npcTypeArea;//Контроллер для классификации типа того, что находится перед врагом
    [SerializeField] DamageArea damageArea;//Зона атаки
    [SerializeField] AudioController audioController;//Контроллер аудио для воспроизведения звуков
    
    private Animator animator;
    private AnimatorSystem animSystem;//Система для проигрывания анимаций
    
    private float health = 100;//Здоровье врага
    public float Health => health;
    
    public void Start()
    {
        animator = GetComponent<Animator>();
        
        animSystem = new AnimatorSystem(animator);
        hitController = new EnemyHitController(animSystem, damageArea);
        movementController = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        movementController.RotateToDirection();//Каждый раз враг поворачивается ко врагу, чтобы избежать 
                                               //остановки врага
        
        if (!hitController.IsHit)
        {
            if (movementController.IsAbleToHit && npcTypeArea.CheckPerson(PersonType.Player))
            {
                //print("Enemy hit");
                //Реагируем при возможности удара соотвествующим образом - проигрываем анимации и вызываем метод удара
                animSystem.Walk(false);
                animSystem.Attack(true);
                
                hitController.ThrowHit();
            }
            else
            {
                //Если удар не возможен и перед врагом не стоит игрок - значит ничего не делаем.
                //Сделано это для того, чтобы при появлении врага перед данным врагом -
                //мы не наносили урон первому и не шли
                animSystem.Walk(false);
                animSystem.Attack(false);
            }
            //Если же у нас происходит так, что перед врагом нет препятсвия в виде врага и нам надо двигаться - двигаемся
            if (movementController.IsAbleToMove && !npcTypeArea.CheckPerson(PersonType.Enemy))
            {
                print("Enemy move");
                animSystem.Attack(false);
                animSystem.Walk(true);
                
                movementController.Move();
            }
        }
        else
        {
            animSystem.Attack(false);
            hitController.StopHit();
        }
        
        if(health <= 0)
        {
            Die();
        }
    }
    
    //Реакция врага при получении урона
    public void GetDamage(float damage)
    {
        if (audioController != null) audioController.PlayPunch();
        health -= damage;
    }
    
    private void Die()
    {
        Destroy(gameObject);//Уничтожаем весь игровой объект врага на сцене
    }
}
