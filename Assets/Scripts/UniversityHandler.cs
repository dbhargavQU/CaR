using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class UniversityHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button saveButton;
    public TextMeshProUGUI displayText;

    private List<string> universities = new List<string>();
    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "universities.txt");
        saveButton.onClick.AddListener(SaveAndResetInput);
        LoadData();
        Debug.Log("Data Path: " + Application.persistentDataPath);
        DisplayData();
    }

    public void SaveAndResetInput()
    {
        if (!string.IsNullOrWhiteSpace(inputField.text) && universities.Count < 5)
        {
            universities.Add(inputField.text);
            SaveData();
            inputField.text = "";
            DisplayData();
        }
        else
        {
            Debug.Log("No input or maximum of 5 universities reached.");
        }
    }

    void SaveData()
    {
        File.WriteAllLines(filePath, universities);
    }

    void LoadData()
    {
        universities.Clear();
        if (File.Exists(filePath))
        {
            universities.AddRange(File.ReadAllLines(filePath));
        }
        DisplayData();
    }

    void DisplayData()
    {
        displayText.text = "Universities:\n" + string.Join("\n", universities);
    }
}
