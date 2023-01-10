using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : Entity
{
     public SpawnerData spawnerData;

     public void Start()
     {
          currentStats = new Stats();
          currentStats.currentHealth = entityData.health;
          SpawnerManager.instance.AddSpawner();
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
               MobManager.instance.SpawnMob(Pooler.instance.Pop(spawnerData.mob.name),Random.insideUnitCircle * spawnerData.spawnRadius + (Vector2) transform.position);
          }
          yield return new WaitForSeconds(Random.Range(spawnerData.minSpawnSpeed, spawnerData.maxSpawnSpeed));
          StartCoroutine(Spawn());
     }
}
