using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{
    [SerializeField] float spawnInterval;
    [SerializeField] float spawnLength;

    [SerializeField] GameObject[] bubbleRedPrefabs;
    [SerializeField] GameObject[] bubbleBluePrefabs;
    [SerializeField] Transform[] transforms;

    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(BubbleSpawnCoroutine());
    }
    
    /// <summary>
    /// Spawns a bubble at a random point in transforms
    /// every spawnInterval seconds
    /// </summary>
    /// <returns></returns>
    private IEnumerator BubbleSpawnCoroutine()
    {
        while (true) {
            // Get random indexes in transforms and bubblePrefabs
            int transformPoint = Random.Range(0, transforms.Length); 

            int category = Random.Range(0, 2);
            GameObject[] bubblePrefabs = category == 0 ? bubbleRedPrefabs : bubbleBluePrefabs;
            int bubbleType = Random.Range(0, bubblePrefabs.Length); 

            yield return new WaitForSeconds(spawnInterval);

            // Instantiate bubble at transforms[index]
            GameObject bubble = Instantiate(bubblePrefabs[bubbleType], transforms[transformPoint].position, Quaternion.identity); 

            // Reduces overhead by deleting bubble once offscrean
            StartCoroutine(BubbleDestroyCoroutine(bubble));
        }
    }

    /// <summary>
    /// Deletes bubble after spawnLength seconds
    /// </summary>
    /// <param name="bubble"> Spawned bubble </param>
    /// <returns></returns>
    private IEnumerator BubbleDestroyCoroutine(GameObject bubble) {
        yield return new WaitForSeconds(spawnLength);
        Destroy(bubble);
    }
}
