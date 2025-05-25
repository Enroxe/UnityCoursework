using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Компонент для проверки зоны изменения
public class NPCTypeArea : MonoBehaviour
{
    [SerializeField] private PersonType requiredType;
    private List<PersonType> currentTypes = new List<PersonType>();

    public bool IsHasType => currentTypes.Contains(requiredType);

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentTypes.Add(GetNearPerson(other.gameObject));
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        currentTypes.Remove(GetNearPerson(other.gameObject));
    }

    public bool CheckPerson(PersonType personType)
    {
        return currentTypes.Contains(personType);
    }
    
    private PersonType GetNearPerson(GameObject person)
    {
        var nearPerson = PersonType.None;
        Enum.TryParse(person.tag.ToString(), out nearPerson);
        
        return nearPerson;
    }
}
public enum PersonType
{
    None,
    Player,
    Enemy
}