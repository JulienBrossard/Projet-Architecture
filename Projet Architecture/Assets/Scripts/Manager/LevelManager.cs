using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Wave> waves;
    [SerializeField] private Transform player;
    private int npcRemaining;
    
    private int currentWave = 0;
    private Npc currentNpc;
    private int randomNpc;
    
    private void Start()
    {
        SpawnWave();
    }
    
    private void SpawnWave()
    {
        foreach (var npc in waves[currentWave].npcs)
        {
            npcRemaining += npc.amount;
        }
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(npcRemaining > 0)
        {
            randomNpc = Random.Range(0, waves[currentWave].npcs.Count);
            currentNpc = waves[currentWave].npcs[randomNpc];
            MobManager.instance.SpawnMobToRandomPosition(Pooler.instance.Pop(currentNpc.npc.name).transform);
            currentNpc.npc.GetComponent<AIDestinationSetter>().target = player;
            currentNpc.amount--;
            if (currentNpc.amount == 0)
            {
                waves[currentWave].npcs.Remove(currentNpc);
            }
            npcRemaining--;
            yield return new WaitForSeconds(Random.Range(0, waves[currentWave].spawnRate));
        }
        yield return new WaitForSeconds(waves[currentWave].timeBetweenWaves);
        if (currentWave < waves.Count - 1)
        {
            currentWave++;
            SpawnWave();
        }
    }
}

[Serializable]
public class Wave
{
    public List<Npc> npcs;
    public float spawnRate;
    public float timeBetweenWaves;
}

[Serializable]
public class Npc
{
    public GameObject npc;
    public int amount;
}
