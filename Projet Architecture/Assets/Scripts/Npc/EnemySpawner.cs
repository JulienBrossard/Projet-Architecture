using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Mob prefabMob;
    [SerializeField] private float spawnCoolDown;

    public IEnumerator SpawnEnemies(int numberToSpawn)
    {
        for (int i = numberToSpawn; i > 0; i--)
        {
            Instantiate(prefabMob);
            yield return new WaitForSeconds(spawnCoolDown);
        }
    } 
}
