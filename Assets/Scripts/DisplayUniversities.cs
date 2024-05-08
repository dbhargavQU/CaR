using UnityEngine;
using TMPro;  // Include the TextMeshPro namespace
using System.Collections.Generic;
using System.IO;

public class DisplayUniversities : MonoBehaviour
{
    public TextMeshProUGUI displayText;  // Reference to the TextMeshProUGUI component to display data
    private List<string> universities = new List<string>();
    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "universities.txt");
        LoadData();
        DisplayData();
        Debug.Log("Data Path: " + Application.persistentDataPath);
    }

    void LoadData()
    {
        universities.Clear();
        if (File.Exists(filePath))
        {
            universities.AddRange(File.ReadAllLines(filePath));
        }
    }

    void DisplayData()
    {
        displayText.text = string.Join("\n", universities);
    }
}
