using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private float life = 1;
    private float maxLife = 1;
    
    public void TakeDamage(float damage, string name)
    {
        life -= damage;
        if (life<0)
        {
            life = maxLife;
            Die(name);
        }
    }

    public void Die(string name)
    {
        Pooler.instance.DePop(name.Replace("(Clone)", String.Empty), gameObject);
    }
}
