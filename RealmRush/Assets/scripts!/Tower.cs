using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Build;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem myParticles;
    void Update()
    {
        if (targetEnemy)
        {
            ShootAtEnemy();
        }
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

