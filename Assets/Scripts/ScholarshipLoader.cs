using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ScholarshipLoader : MonoBehaviour
{
    private string filePath = "scholarships.txt"; // File name to be used

    void Start()
    {
        // Example usage
        List<string> scholarships = LoadScholarships();
        foreach (var scholarship in scholarships)
        {
            Debug.Log(scholarship);
        }
    }

    public List<string> LoadScholarships()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, filePath);
        List<string> scholarships = new List<string>();

        if (File.Exists(fullPath))
        {
            string[] lines = File.ReadAllLines(fullPath);
            scholarships.AddRange(lines);
        }
        else
        {
            Debug.LogError("Cannot find the file: " + fullPath);
        }

        return scholarships;
    }
}
