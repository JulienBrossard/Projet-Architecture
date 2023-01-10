using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> mapSpawners;
    [SerializeField] private Map currentMap;

    public void InitialiseMap()
    {
        mapSpawners = currentMap.GetMapSpawners();
    }

    /*public void ActivateSpawners(int numberToSpawn)
    {
        foreach (var spawner in mapSpawners)
        {
            spawner.StartCoroutine(spawner.SpawnEnemies(numberToSpawn));
        }
    }*/
}
