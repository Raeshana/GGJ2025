using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] float spawnInterval;
    [SerializeField] float spawnLength;
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
            // Get random index in transforms
            int point = Random.Range(0, transforms.Length-1); 

            yield return new WaitForSeconds(spawnInterval);

            // Instantiate bubble at transforms[index]
            GameObject bubble = Instantiate(bubblePrefab, transforms[point].position, Quaternion.identity); 

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
