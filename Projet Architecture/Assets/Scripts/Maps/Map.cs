using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> mapSpawners;

    public List<EnemySpawner> GetMapSpawners()
    {
        return mapSpawners;
    }
}
