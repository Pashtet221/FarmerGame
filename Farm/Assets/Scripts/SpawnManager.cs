using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int poolCount = 3;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Apple prefab;

    private PoolMono<Apple> pool;

    [SerializeField] private float areaX = 3;
    [SerializeField] private float areaY = 1;

    private float spawnRate = 5f;
    public bool isGameActive;

    private void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());

        this.pool = new PoolMono<Apple>(prefab, poolCount, transform);
        this.pool.autoExpand = autoExpand;
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-areaX, areaX), Random.Range(-areaY, areaY));
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            var applePrefab = pool.GetFreeELement();
            applePrefab.transform.position = RandomSpawnPos();
        }
    }
}
