using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 3f;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform enemyParentTransform;
    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        while (true) // forever!
        {
            var enemies = Instantiate(enemy, transform.position, Quaternion.identity);
            enemies.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawn);        
        }
    }
}
