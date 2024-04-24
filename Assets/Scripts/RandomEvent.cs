using Dreamteck.Splines;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomEvent : MonoBehaviour
{
    [SerializeField]
    private List<EventInfo> Events = new List<EventInfo>();

    [SerializeField]
    private GameObject OptionButtonPrefab, OptionButtonHolder, OptionsButtonCloser;
    [SerializeField]
    private TMP_Text EventDescription;
    [SerializeField]
    private SplineFollower Car;
    public void Start()
    {
        EventInitialize();
    }
    public EventInfo SelectRandom()
    {
        var random = Random.Range(0, 10);
        Debug.Log(random);
        return Events[random];
    }

    public void ModResources(float FoodMod, float FuelMod, float MoneyMod)
    {
        Resources.FoodAmount += FoodMod;
        Resources.FuelAmount += FuelMod;
        Resources.MoneyAmount += MoneyMod;
    } //catch case for changing resources w/o buttons

    public void EventInitialize()
    {
        Car.follow = false;
        OptionsButtonCloser.SetActive(false);
        foreach (Transform child in OptionButtonHolder.transform)
        {
            Destroy(child.gameObject);
        } //clear options

        EventInfo ChosenEvent = SelectRandom(); //choose random event
        EventDescription.text = ChosenEvent.Description; //set description
        foreach (var choices in ChosenEvent.Choices)
        {
            GameObject OptionButton = Instantiate(OptionButtonPrefab, OptionButtonHolder.transform);
            OptionButton.GetComponentInChildren<TMP_Text>().text = choices.Description; //instantiate new options
            OptionButton.GetComponent<OptionHandler>().FoodMod = choices.FoodMod;
            OptionButton.GetComponent<OptionHandler>().FuelMod = choices.FuelMod;
            OptionButton.GetComponent<OptionHandler>().MoneyMod = choices.MoneyMod;
            OptionButton.GetComponent<OptionHandler>().OutcomeText = choices.Outcome;
            OptionButton.GetComponent<Button>().onClick.AddListener(CanvasCloseActive);
        }
    }
    public void CanvasCloseActive()
    {
        OptionsButtonCloser.SetActive(true);
    }
    public void CarFollowToggle()
    {
        Car.follow = !Car.follow;
    }
}

[System.Serializable]
public class EventInfo
{
    public string Title, Description;
    public List<Choices> Choices = new List<Choices>();
}
[System.Serializable]
public class Choices
{
    public string Description, Outcome;
    [Range(-10, 10)] public float FoodMod, FuelMod;
    [Range(-100, 100)] public float MoneyMod;
}