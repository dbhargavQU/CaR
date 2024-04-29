using UnityEngine;
using TMPro;

public class ScheduleDisplay : MonoBehaviour
{
    public TMP_Dropdown dropdown;        // Drag the Dropdown component here in the inspector
    public TMP_InputField inputField;    // Drag the Input Field component here in the inspector
    public TMP_Text displayText;         // Drag the Text component here in the inspector

    // This function is called when the submit button is clicked
    public void OnSubmitClicked()
    {
        // Check if the input field is not empty
        if (!string.IsNullOrEmpty(inputField.text))
        {
            // Append the new schedule entry to the existing text, adding a new line for each submission
            displayText.text += "Schedule for " + dropdown.options[dropdown.value].text + ": " + inputField.text + "\n";

            // Remove the selected item from the dropdown to prevent duplicate entries
            RemoveScholarshipFromDropdown(dropdown.value);

            // Clear the input field after submitting
            inputField.text = "";
        }
        else
        {
            // Optionally handle the case where the input field is empty
            displayText.text = "Please enter a schedule!";
        }
    }

    // Function to remove a scholarship from the dropdown
    void RemoveScholarshipFromDropdown(int index)
    {
        if (dropdown.options.Count > index) // Check if the index is valid
        {
            dropdown.options.RemoveAt(index); // Remove the option at the specified index
            dropdown.RefreshShownValue(); // Refresh the dropdown to show the updated list
        }
    }
}
