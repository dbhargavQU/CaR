using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class TextInputHandler1 : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button saveButton;
    public TextMeshProUGUI displayText;  // Reference to the TextMeshPro UI component

    private List<string> scholarships = new List<string>();
    private string filePath;

    void Start()
    {
        filePath = @"Assets\university.txt";
        saveButton.onClick.AddListener(SaveAndResetInput);
        LoadScholarships();
        DisplayScholarships();
    }

    public void SaveAndResetInput()
    {
        if (inputField == null)
        {
            Debug.LogError("Attempted to use an unassigned Input Field!");
            return;
        }

        if (scholarships.Count < 5)
        {
            scholarships.Add(inputField.text);
            SaveScholarshipsToFile();
            Debug.Log("Saved Uni: " + inputField.text);
            inputField.text = ""; // Reset the input field
            DisplayScholarships();  // Update the display text
        }
        else
        {
            Debug.Log("Maximum of 5 Universities are allowed.");
            inputField.text = ""; // Optionally reset even if no more entries can be made
        }
    }

    void SaveScholarshipsToFile()
    {
        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        using (StreamWriter sw = new StreamWriter(filePath, false))
        {
            foreach (string scholarship in scholarships)
            {
                sw.WriteLine(scholarship);
            }
        }
    }

    void LoadScholarships()
    {
        scholarships.Clear();
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    scholarships.Add(line);
                }
            }
        }
        DisplayScholarships();
    }

    void DisplayScholarships()
    {
        if (displayText == null)
        {
            Debug.LogError("Display Text not assigned!");
            return;
        }

        displayText.text = "Universities:\n";
        foreach (string scholarship in scholarships)
        {
            displayText.text += scholarship + "\n";
        }
    }
}