using UnityEngine;
using TMPro;  // Include the TextMeshPro namespace
using System.Collections.Generic;
using System.IO;

public class DisplayScholarships : MonoBehaviour
{
    public TextMeshProUGUI displayText;  // Reference to the TextMeshProUGUI component to display data
    private List<string> scholarships = new List<string>();
    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "scholarships.txt");
        LoadData();
        DisplayData();
        Debug.Log("Data Path: " + Application.persistentDataPath);
    }

    void LoadData()
    {
        scholarships.Clear();
        if (File.Exists(filePath))
        {
            scholarships.AddRange(File.ReadAllLines(filePath));
        }
    }

    void DisplayData()
    {
        displayText.text = string.Join("\n", scholarships);
    }
}
