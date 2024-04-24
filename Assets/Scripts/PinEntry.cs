using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class PinEntry : MonoBehaviour
{
    public TMP_InputField pinInputField;
    public string correctPin = "1234";
    public string nextSceneName = "NextScene";

    public void CheckPinAndLoadScene()
    {
        if(pinInputField.text == correctPin)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("Incorrect PIN"); 
        }
    }
}
