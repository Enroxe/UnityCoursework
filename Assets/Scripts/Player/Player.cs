using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] float health = 100;
    float maxHealth = 0;
    
    [SerializeField] AudioController audioController;
    
    
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value > maxHealth)
            {
                health = maxHealth;
            }
            health = value;
        }
    }
    
    public LevelMenu levelMenu;
    public AnimatorSystem AnimSystem;
    public PlayerHitController HitController;
    public PlayerMovement Movement;
    
    
    public DamageArea DamageArea;
    
    void Start()
    {
        maxHealth = health;
        
        Cursor.visible = false;
        
        AnimSystem = new AnimatorSystem(gameObject.GetComponent<Animator>());
        HitController = new PlayerHitController(AnimSystem, DamageArea);
        Movement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        Movement.Move();
        GetInputs();

        if (health <= 0)
        {
            print(health);
            Die();
        }
    }

    public void GetInputs()
    {
        print(HitController.IsHit);
        if (!HitController.IsHit)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("Hit");
                HitController.ThrowHit();
                AnimSystem.Attack(true);
            }
        }
        else
        {
            print("Stop hit");
            HitController.StopHit();
            AnimSystem.Attack(false);
        }

        if (Movement.IsMoving)
        {
            AnimSystem.Walk(true);
        }
        else
        {
            AnimSystem.Walk(false);
        }
    }
    
    public void Heal(float value)
    {
        Health += value;
    }

    public void IncreaseSpeed(float value)
    {
        Movement.MoveSpeed += value;
    }
    
    public void GetDamage(float damage)
    {
        if (audioController != null)  audioController.PlayPunch();
        health -= damage;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        levelMenu.ActivateGameOver();
    }
}
