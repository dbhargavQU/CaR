using UnityEngine;
using TMPro;

public class ColorAnimation : MonoBehaviour
{
    public TMP_Text textComponent;  // Reference to the TextMeshPro component
    public Color startColor = Color.red;  // Starting color
    public Color endColor = Color.blue;  // Ending color
    public float speed = 1.0f;  // Speed of the color transition

    private float startTime;

    void Start()
    {
        if (textComponent == null)
            textComponent = GetComponent<TMP_Text>();  // Automatically get the TMP_Text component if not assigned
        startTime = Time.time;
    }

    void Update()
    {
        // Calculate the fraction of the time that has passed
        float t = Mathf.Sin((Time.time - startTime) * speed) * 0.5f + 0.5f;
        textComponent.color = Color.Lerp(startColor, endColor, t);
    }
}
