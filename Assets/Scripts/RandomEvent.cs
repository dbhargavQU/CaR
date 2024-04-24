using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvent : MonoBehaviour
{
    [SerializeField]
    private List<EventInfo> Events = new List<EventInfo>();

    public EventInfo SelectRandom()
    {
        var random = Random.Range(0,10);
        return Events[random];
    }
    
    public void ModResources(float FoodMod, float FuelMod, float MoneyMod)
    {
        Resources.FoodAmount += FoodMod;
        Resources.FuelAmount += FuelMod;
        Resources.MoneyAmount = +MoneyMod;
    }
}

[System.Serializable]
public class EventInfo
{
    [SerializeField]
    private string Title, Description;
    [SerializeField]
    private List<Choices> Choices = new List<Choices>();
}
[System.Serializable] 
public class Choices
{
    [SerializeField]
    private string Description,Outcome;
    [SerializeField]
    [Range(-10, 10)] private float FoodMod, FuelMod;
    [SerializeField]
    [Range(-100, 100)] private float MoneyMod;
}