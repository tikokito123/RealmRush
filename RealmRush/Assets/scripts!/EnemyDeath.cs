using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] GameObject deathFx;
    [SerializeField] ParticleSystem hit;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;
    public int health = 3;
    void OnParticleCollision(GameObject other)
    {
        Death();   
    }

    private void Death()
    {
        
        if (health <= 0)
        {
            var vfx = Instantiate(deathFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<AudioSource>().PlayOneShot(deathSFX);
            Destroy(vfx.gameObject, 1f);
        }
        health--;
        hit.Play();
        FindObjectOfType<AudioSource>().PlayOneShot(hitSFX);
    }
}
