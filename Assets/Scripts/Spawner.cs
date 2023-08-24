using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnInterval = 1.0f;
    public Vector2 spawnAreaSize = new Vector3(10, 10);

    public void StartSpawner()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            Vector2 randomPosition = transform.position + new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
            );

            int number = Random.Range(0, objectsToSpawn.Length);

            Instantiate(objectsToSpawn[number], randomPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}