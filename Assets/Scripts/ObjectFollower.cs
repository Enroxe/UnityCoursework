using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Класс для передвижения объекта за другим объектом
//Используется для камеры
public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private GameObject target;

    public void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.transform.position.x,
                target.transform.position.y,
                gameObject.transform.position.z);
        }
    }
}
