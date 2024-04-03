using UnityEngine;
using UnityEngine.SceneManagement; 


public class SceneSwitcher : MonoBehaviour
{
    // This method will be called on button click.
    // Pass the name of the scene you want to switch to.
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
