using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Класс для передвижения врага
public class EnemyMovement : MonoBehaviour, IMoveAble
{
    private GameObject playerObject;
    
    [SerializeField] float speed = 2f;              // Скорость передвижения
    [SerializeField] float stopRange = 2f;          // Дистанция остановки движения
    [SerializeField] float distanceToAgre = 10f;    // Дистанция для активации врага
    
    //Флаги для контроля передвижения
    //Может ли враг наносить урон
    private bool isAbleToHit = false;
    public bool IsAbleToHit
    {
        get { return isAbleToHit; }
    }
    
    //Может ли враг передвигаться
    private bool isAbleToMove = false;
    public bool IsAbleToMove
    {
        get { return isAbleToMove; }
    }
    
    //Свойство текущей дистанции до игрока
    private float DistanceToPlayer
    {
        get
        {
            if(playerObject != null) return Vector2.Distance(transform.position, playerObject.transform.position);
            return 0;
        }
    }
    
    //Свойство текущего направления до игрока
    private Vector2 currentDirection
    {
        get
        {
            if(playerObject != null) return (playerObject.transform.position - transform.position).normalized * (speed * Time.deltaTime);
            return new Vector2(0,0);
        }
    }
    
    private void Start()
    {
        //В самом начале находим персонажа на сцене и сохраняем его ссылку
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (playerObject == null) return;

        if (DistanceToPlayer < distanceToAgre)
        {
            isAbleToMove = false;
            
            if (DistanceToPlayer > stopRange)
            {
                isAbleToMove = true;
                isAbleToHit = false;
            }
            else
            {
                isAbleToMove = false;
                isAbleToHit = true;
            }
        }
        else
        {
            isAbleToMove = false;
            isAbleToHit = false;
        }
    }

    //Метод для передвижения врага
    public void Move()
    {
        Vector2 direction = (playerObject.transform.position - transform.position).normalized * (speed * Time.deltaTime);
        transform.position += (Vector3)direction;
    }
    
    //Поворот к игроку
    public void RotateToDirection()
    {
        float direction = currentDirection.x;
        
        if (direction > 0)
        {
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 180;
            transform.rotation = Quaternion.Euler(rotate);
        }
        else if(direction < 0){
            Vector3 rotate = transform.eulerAngles;
            rotate.y = 0;
            transform.rotation = Quaternion.Euler(rotate);
        }
    }
}
