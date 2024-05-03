using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class TextInputHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button saveButton;
    public TextMeshProUGUI displayText;

    private List<string> scholarships = new List<string>();
    private string filePath;

    void Start()
    {
        // Use Application.persistentDataPath to ensure the path is correct on all platforms
        filePath = Path.Combine(Application.persistentDataPath, "scholarships.txt");
        saveButton.onClick.AddListener(SaveAndResetInput);
        LoadScholarships();
        DisplayScholarships();
    }

    public void SaveAndResetInput()
    {
        if (inputField.text.Trim().Length > 0) // Check if the input is not just white spaces
        {
            if (scholarships.Count < 5)
            {
                scholarships.Add(inputField.text.Trim());
                SaveScholarshipsToFile();
                inputField.text = "";
                DisplayScholarships();
            }
            else
            {
                Debug.Log("Maximum of 5 scholarships are allowed.");
            }
        }
    }

    void SaveScholarshipsToFile()
    {
        // Ensure the directory exists
        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // Save to file
        File.WriteAllLines(filePath, scholarships);
    }

    void LoadScholarships()
    {
        scholarships.Clear();
        if (File.Exists(filePath))
        {
            scholarships.AddRange(File.ReadAllLines(filePath));
        }
        DisplayScholarships();
    }

    void DisplayScholarships()
    {
        displayText.text = "Scholarships:\n" + string.Join("\n", scholarships);
    }
}
