using System.Collections;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    
    [SerializeField] private float spawnInterbal;

    [SerializeField] private Vector3 minSpawnPos;
    [SerializeField] private Vector3 maxSpawnPos;

    private IEnumerator SpawnApple()
    {
        float lastSpawnTime = 0;

        while (true)
        {
            if (Time.time - lastSpawnTime > spawnInterbal)
            {
                var spawnX = Random.Range(minSpawnPos.x, maxSpawnPos.x);
                var spawnY = Random.Range(minSpawnPos.y, maxSpawnPos.y);

                var spawnPos = new Vector3(spawnX, spawnY);

                Instantiate(applePrefab, spawnPos, Quaternion.identity);

                lastSpawnTime = Time.time;
            }

            yield return null;
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnApple());
    }
}
