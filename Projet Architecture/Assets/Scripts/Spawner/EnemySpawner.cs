using System;
using System.Collections;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;

public class EnemySpawner : Entity
{
    public SpawnerData spawnerData;
    private const float firstWaveSpawnDelay = 3f;

    public void Start()
    {
        currentStats = new Stats();
        currentStats.currentHealth = entityData.health;
        SpawnerManager.instance.AddSpawner();
        Invoke(nameof(Init), firstWaveSpawnDelay);
    }

    private void Init()
    {
        StartCoroutine(Spawn());
    }

    public override void Die(string name)
    {
        base.Die(name);
        SpawnerManager.instance.RemoveSpawner();
        Destroy(gameObject);
    }

    IEnumerator Spawn()
    {
        int spawnCount = Random.Range(spawnerData.minNpcSpawn, spawnerData.maxNpcSpawn);
        for (int i = 0; i < spawnCount; i++)
        {
            MobManager.instance.SpawnMob(Pooler.instance.Pop(spawnerData.mob.name), Random.insideUnitCircle * spawnerData.spawnRadius + (Vector2)transform.position);
        }
        yield return new WaitForSeconds(Random.Range(spawnerData.minSpawnSpeed, spawnerData.maxSpawnSpeed));
        StartCoroutine(Spawn());
    }
}
