using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Build;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem myParticles;
    //state
    Transform targetEnemy;
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            ShootAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDeath>();
        if (sceneEnemies.Length == 0) { return; }
        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (EnemyDeath Enemies in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, Enemies.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA,Transform transformB)
    {
        var distToA = Vector3.Distance(transformA.position, transform.position);
        var distToB = Vector3.Distance(transformA.position, transform.position);
        if (distToA <= distToB)
        {
            return transformA;
        }
            return transformB;
    }

    private void ShootAtEnemy()
    {
        float dist = Vector3.Distance(targetEnemy.position, transform.position);
        if (dist < attackRange)
        {
            objectToPan.LookAt(targetEnemy);
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionMoudle = myParticles.emission;
        emissionMoudle.enabled = isActive;
    }
}

