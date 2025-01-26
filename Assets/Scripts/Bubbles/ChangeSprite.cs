using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        // Get random indexes in sprites
        int spriteIndex = Random.Range(0, sprites.Length); 
        sr.sprite = sprites[spriteIndex];
    }
}
