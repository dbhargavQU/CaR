using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteManager : MonoBehaviour
{
    public SpriteSwitcher spriteSwitcher; // Assign in inspector
    public Button[] buttons; // Assign all your buttons in the inspector

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Local copy for closure
            buttons[i].onClick.AddListener(() => spriteSwitcher.ChangeSprite(index));
        }
    }
}
