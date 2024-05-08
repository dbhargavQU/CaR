using UnityEngine;
using System.Collections;

public class DelayedDisplay : MonoBehaviour
{
    public GameObject[] gameObjectsToDisplay;  // Array to hold the GameObjects you want to display
    public float delayTime = 40f;  // Default delay time, set to 40 seconds. You can edit this in the Inspector.

    void Start()
    {
        // Start the coroutine to delay the display of game objects
        StartCoroutine(DisplayAfterDelay(delayTime));  // Use the public variable for delay
    }

    IEnumerator DisplayAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Wait for the specified delay

        // Activate each game object in the array
        foreach (GameObject obj in gameObjectsToDisplay)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
