using System.Collections;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private Apple applePrefab;

    [SerializeField] private int spawnCnt;

    [SerializeField] private Vector3 minSpawnPos;
    [SerializeField] private Vector3 maxSpawnPos;

    public Apple SpawnApple(Vector3 pos)
    {
        return Instantiate(applePrefab, pos, Quaternion.identity);
    }

    private void SpawnApples()
    {
        for (int i = 0; i < spawnCnt; i++)
        {
            var spawnPos = RandomPosition(minSpawnPos, maxSpawnPos);
            SpawnApple(spawnPos).Initialize(Apple.State.Normal);
        }
    }

    public static Vector3 RandomPosition(Vector3 min, Vector3 max)
    {
        var x = Random.Range(min.x, max.x);
        var y = Random.Range(min.y, max.y);
        var z = Random.Range(min.z, max.z);

        var pos = new Vector3(x, y, z);

        return pos;
    }

    private void HandleAppleHarvested()
    {
        if (Apple.IsEmpty()) SpawnApples();
    }

    private void OnEnable()
    {
        Apple.onAppleHarvested += HandleAppleHarvested;
    }

    private void OnDisable()
    {
        Apple.onAppleHarvested -= HandleAppleHarvested;
    }

    private void Start()
    {
        SpawnApples();
    }
}
