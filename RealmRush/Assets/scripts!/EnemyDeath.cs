using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] ParticleSystem hit;
    public int health = 3;
    void OnParticleCollision(GameObject other)
    {
        Death();   
    }

    private void Death()
    {
        
        if (health <= 0)
        {
            Instantiate(deathFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        health--;
        hit.Play();
    }
}
