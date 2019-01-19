using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public int atk;
    
    private int health;
    public int maxHealth;

    public GameObject hand;
    
    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (health - amount <= 0)
            OnDie();
        else
        {
            health -= amount;
        }
    }

    public void AddHealth(int amount)
    {
        health += amount;
    }

    public abstract void OnDie();
}
