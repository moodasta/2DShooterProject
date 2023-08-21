using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawmer : MonoBehaviour
{
    [SerializeField] Vector2 minSpawnPosition, maxSpawmPosition;
    [SerializeField] GameObject enemyDino;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            float xPosition = Random.Range(minSpawnPosition.x, maxSpawmPosition.x);
            float yPosition = Random.Range(minSpawnPosition.y, maxSpawmPosition.y);
            Instantiate(enemyDino, new Vector2(xPosition, yPosition),
                Quaternion.identity);
        }
    }

}
