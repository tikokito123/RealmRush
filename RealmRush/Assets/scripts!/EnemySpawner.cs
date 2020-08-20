using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawn = 3f;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text enemiesText;
    int numOfEnemies;
    private void Start()
    {
        StartCoroutine(EnemySpawn());
        enemiesText.text = numOfEnemies.ToString();
    }
    IEnumerator EnemySpawn()
    {
        while (true) // forever!
        {
            var enemies = Instantiate(enemy, transform.position, Quaternion.identity);
            enemies.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawn);
            numOfEnemies++;
            enemiesText.text = numOfEnemies.ToString();

        }
    }
}
