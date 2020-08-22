using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int hit = 10;
    [SerializeField] Text amountOfHealth;
    [SerializeField] Text gameOver;
    public bool alive = true;
    private void Start()
    {
        amountOfHealth.text = health.ToString();
    }
    private void Update()
    {
        if (health == 0)
        {
            alive = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        health = health - hit;
        amountOfHealth.text = health.ToString();
    }
    
}
