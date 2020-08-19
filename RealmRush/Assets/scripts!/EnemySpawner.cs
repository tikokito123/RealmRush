using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawn = 3f;
    [SerializeField] GameObject enemy;
    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        while (true) // forever!
        {
            Instantiate(enemy,new Vector3(0,0,0), Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawn);        
        }
    }
}
