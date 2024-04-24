using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionHandler : MonoBehaviour
{
    public float FoodMod, FuelMod, MoneyMod;
    public string OutcomeText;
    public TMP_Text Description;
    private void OnEnable()
    {
        Description = gameObject.transform.parent.parent.GetComponentInChildren<TMP_Text>();
    }
    public void OptionSelected()
    {
        Resources.FoodAmount += FoodMod;
        Resources.FuelAmount += FuelMod;
        Resources.MoneyAmount += MoneyMod;
        Description.text = OutcomeText;
        var parent = gameObject.transform.parent;
        parent.gameObject.SetActive(false);
    }
}
