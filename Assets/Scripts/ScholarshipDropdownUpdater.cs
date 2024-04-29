using UnityEngine;
using TMPro; 
using System.Collections.Generic;

public class ScholarshipDropdownUpdater : MonoBehaviour
{
    public TMP_Dropdown dropdown; // Assign this in the Inspector
    public ScholarshipLoader scholarshipLoader; // Assign a GameObject with the ScholarshipLoader script

    void Start()
    {
        if (scholarshipLoader == null)
            scholarshipLoader = GetComponent<ScholarshipLoader>(); // Fallback to the same GameObject if not assigned

        List<string> scholarships = scholarshipLoader.LoadScholarships();
        UpdateDropdown(scholarships);
    }

    void UpdateDropdown(List<string> items)
    {
        dropdown.ClearOptions(); // Clear existing options
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        foreach (var item in items)
        {
            options.Add(new TMP_Dropdown.OptionData(item)); // Create and add new option
        }

        dropdown.AddOptions(options); // Add all collected options
    }
}
