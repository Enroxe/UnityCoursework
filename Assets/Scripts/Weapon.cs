using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage = 25;
    public GameObject OwnerObject;

    public float Damage { get { return damage; } }
}
