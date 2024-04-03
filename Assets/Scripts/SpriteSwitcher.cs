using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Make sure to include the UI namespace

public class SpriteSwitcher : MonoBehaviour
{
    public List<Sprite> sprites; // Your list of sprites
    public GameObject carSpriteGameObject; // Your CarSprite GameObject

    // New method to change the sprite based on an index
    public void ChangeSprite(int spriteIndex)
    {
        if (sprites == null || sprites.Count <= spriteIndex)
        {
            Debug.LogError("Invalid sprite index!");
            return;
        }

        carSpriteGameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
    }
}
