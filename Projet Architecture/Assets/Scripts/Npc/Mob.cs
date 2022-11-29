using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Mob : Entity
{
    [SerializeField] private MobData mobdata;

    public override void TakeDamage(float damage, string name)
    {
        base.TakeDamage(damage, name);
    }

    public override void Die(string name)
    {
        base.Die(name);
        if (mobdata.collectibleSpawnChance != 0 && Math.Round(Random.Range(0f, 1f)) <= mobdata.collectibleSpawnChance)
        {
            Pooler.instance.Pop(mobdata.collectiblesPrefab[Random.Range(0, mobdata.collectiblesPrefab.Length)].name).transform.position = transform.position;
        }
        Pooler.instance.DePop(name.Replace("(Clone)", String.Empty), gameObject);
    }
}
