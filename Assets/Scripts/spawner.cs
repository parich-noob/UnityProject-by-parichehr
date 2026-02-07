using System.Collections;
using UnityEngine;

public class spawner : MonoBehaviour
{
    private Collider2D spawnArea;

    [Header("Enemies")]
    public GameObject[] enemyPrefabs;

    [Header("Spawn Timing")]
    public float minSpawnDelay = 0.5f;
    public float maxSpawnDelay = 1.5f;

    public float maxLifeTime = 8f;

    private void Awake()
    {
        spawnArea = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.5f); // تاخیر اولیه

        while (true)
        {
            GameObject prefab =
                enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            Vector2 position = new Vector2(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y)
            );

            GameObject enemy = Instantiate(prefab, position, Quaternion.identity);

            Destroy(enemy, maxLifeTime);

            yield return new WaitForSeconds(
                Random.Range(minSpawnDelay, maxSpawnDelay)
            );
        }
    }
}
