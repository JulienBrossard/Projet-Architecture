using System;
using System.Collections.Generic;
using UB.Simple2dWeatherEffects.Standard;
using UnityEngine;
using UnityEngine.Events;

public enum Biome { NONE, Arctic, Desert, Jungle }
public enum GameplayEvent { NONE, Fog, Blizzard, Strike }


public class GameplayEventsManager : MonoBehaviour
{
    public static GameplayEventsManager Instance;
    public Biome currentBiome; // REFACTOR: not supposed to be here
    private GameplayEvent gameplayEvent;

    [Header("-- FOG --")]
    [SerializeField] private List<D2FogsPE> fogs;

    [Header("-- BLIZZARD --")]
    [SerializeField] private GameObject SnowVFXContainer;

    [Header("-- FIREBALLS --")]
    [SerializeField] private Transform FireballsVFXParent;
    [SerializeField] private GameObject[] FireballsPrefabs = new GameObject[3];
    [SerializeField, Range(0.05f, 2)] private float minSpawnRate = 0.5f;
    [SerializeField, Range(2, 5)] private float maxSpawnRate = 2;
    [SerializeField, Range(1, 3)] private int minSpawnAmount = 1;
    [SerializeField, Range(3, 10)] private int maxSpawnAmount = 3;
    [SerializeField, Range(1, 5)] private int callAmount = 3;
    private int currentCall; 

    private float spawnRate;
    private int spawnAmount; 

    public Action<GameplayEvent> OnGameplayEventTrigger; // notify scripts to change data like speed, damage, accuracy etc..

    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance); 
        }
        Instance = this; 
    }

    private void Start()
    {
        Init();
        TriggerEvent(currentBiome); // DEBUG
    }

    private void Init()
    {
        SnowVFXContainer.SetActive(false);

        for (int i = 0; i < fogs.Count; i++)
        {
            fogs[i].enabled = false;
        }
    }

    /// <summary>
    /// Call this to get notified by global gameplay events like blizzard, fog or drone strikes
    /// </summary>
    public void SubscribeToEvent(Action<GameplayEvent> callback)
    {
        OnGameplayEventTrigger += callback;
    }

    // REFACTOR: State Pattern
    public void TriggerEvent(Biome currentBiome)
    {
        if (currentBiome == Biome.NONE) return;

        switch (currentBiome)
        {
            case Biome.Arctic:
                TriggerBlizzardEvent();
                break;
            case Biome.Desert:
                TriggerStrikeEvent();
                break;
            case Biome.Jungle:
                TriggerFogEvent();
                break;
        }

        //OnGameplayEventTrigger(gameplayEvent); 
    }

    // REFACTOR: turn into individual components inheriting from an abstract GameplayEvent class
    private  void TriggerBlizzardEvent()
    {
        SnowVFXContainer.SetActive(true);
    }

    // REFACTOR: turn into individual components inheriting from an abstract GameplayEvent class
    private void TriggerStrikeEvent()
    {
        spawnRate = UnityEngine.Random.Range(minSpawnRate, maxSpawnRate);
        InvokeRepeating(nameof(SpawnFireballs), 0f, spawnRate); 
    }

    private void SpawnFireballs()
    {
        if (currentCall == callAmount)
        {
            CancelInvoke(nameof(SpawnFireballs));
            return; 
        }

        Vector2 dir = new Vector3(UnityEngine.Random.Range(-0.4f, 0.4f), UnityEngine.Random.Range(-0.8f, -1)).normalized;

        for (int i = 0; i < FireballsPrefabs.Length; i++)
        {
            spawnAmount = UnityEngine.Random.Range(minSpawnAmount, maxSpawnAmount);
            float randX = UnityEngine.Random.Range(-10f, 10f);

            for (int j = 0; j < spawnAmount; j++)
            {
                GameObject instance = Instantiate(FireballsPrefabs[i], FireballsVFXParent.position + new Vector3(randX, 0), Quaternion.identity);
                instance.GetComponent<Fireball>().Init(dir); 
            }
        }

        currentCall++; 
    }

    // REFACTOR: turn into individual components inheriting from an abstract GameplayEvent class
    private void TriggerFogEvent()
    {
        for (int i = 0; i < fogs.Count; i++)
        {
            fogs[i].enabled = true; 
        }
    }
}
