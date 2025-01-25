using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] float waitTime;
    [SerializeField] Transform[] transforms;
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(BubbleSpawnCoroutine());
    }

    private IEnumerator BubbleSpawnCoroutine()
    {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            Instantiate(bubblePrefab, transforms[0].position, Quaternion.identity);
        }
    }
}
