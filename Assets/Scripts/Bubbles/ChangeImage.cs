using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] Image Image;
    [SerializeField] Sprite[] images;

    // Start is called before the first frame update
    void Start()
    {
        // Get random indexes in transforms and bubblePrefabs
        int imageIndex = Random.Range(0, images.Length); 
        Image.sprite = images[imageIndex];
    }
}
