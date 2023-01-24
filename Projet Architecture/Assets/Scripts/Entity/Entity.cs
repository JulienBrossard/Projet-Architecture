using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Stats currentStats;
    public EntityData entityData;

    private void Start()
    {
        currentStats = new Stats();
        currentStats.currentHealth = entityData.health;
    }

    public virtual void TakeDamage(float damage, string name)
    {
        currentStats.currentHealth -= damage;
        if ( currentStats.currentHealth<0)
        {
            currentStats.currentHealth = entityData.health;
            Die(name);
        }
    }
    
    public virtual void TakeDamage(float damage)
    {
        currentStats.currentHealth -= damage;
        if ( currentStats.currentHealth<0)
        {
            currentStats.currentHealth = entityData.health;
            Die();
        }
    }

    public virtual void Die(string name)
    {
        if (PlayerManager.instance.playerCollision.damageDictionary.ContainsKey(gameObject))
        {
            StopCoroutine(PlayerManager.instance.playerCollision.damageDictionary[gameObject]);
            PlayerManager.instance.playerCollision.damageDictionary.Remove(gameObject);
        }
    }
    public virtual void Die()
    {
        
    }
    
}

[Serializable]
public class Stats
{
    public float currentHealth;
}
