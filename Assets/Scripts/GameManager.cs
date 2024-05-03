using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton instance
    public float SplineStartPosition = 0f;  // Default start position

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Make this object persistent
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this method to change scenes and update the start position
    public void ChangeScene(float newPosition, string sceneName)
    {
        SplineStartPosition = newPosition;  // Update the start position
        SceneManager.LoadScene(sceneName);
    }
}
