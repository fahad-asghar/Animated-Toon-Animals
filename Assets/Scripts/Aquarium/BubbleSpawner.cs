using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    [SerializeField] float spawnRate;

    private void Start()
    {
        SpawnBubbles();
    }

    private void SpawnBubbles()
    {
        GameObject obj = Instantiate(bubble, new Vector2(Random.Range(-22, 22), -5.9f), Quaternion.identity);
        float random = Random.Range(0.5f, 1);
        obj.transform.localScale = new Vector2(random, random);

        Invoke("SpawnBubbles", spawnRate);
    }
}
