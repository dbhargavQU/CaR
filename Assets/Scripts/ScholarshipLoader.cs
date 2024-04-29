using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ScholarshipLoader : MonoBehaviour
{
    public string filePath = @"Assets\scholarships.txt"; // Path relative to the Assets folder
    public List<string> LoadScholarships()
    {
        string fullPath = Path.Combine(Application.dataPath, filePath);
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
