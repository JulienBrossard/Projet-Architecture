using System;
using System.Collections.Generic;
using UB.Simple2dWeatherEffects.Standard;
using UnityEngine;

public enum Biome { NONE, Arctic, Desert, Jungle }
public enum GameplayEvent { NONE, Fog, Blizzard, Strike }


public class GameplayEventsManager : MonoBehaviour
{
    public static GameplayEventsManager Instance;
    public Biome currentBiome;
    private GameplayEvent gameplayEvent;

    [Header("-- FOG --")]
    [SerializeField] private GameObject fogVFX;

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
        SnowVFXContainer.SetActive(false);
        fogVFX.SetActive(false);

        float delay = UnityEngine.Random.Range(15, 45);
        Invoke(nameof(Init), delay);
    }

    private void Init()
    {
        TriggerEvent(currentBiome);
    }

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
    }

    private void TriggerBlizzardEvent()
    {
        SnowVFXContainer.SetActive(true);

        PlayerManager.instance.GetGunData().fireRate *= 0.5f;
        UIManager.instance.fireRateBonus.text = PlayerManager.instance.GetGunData().fireRate.ToString();
    }

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

    private void TriggerFogEvent()
    {
        fogVFX.SetActive(true);
        PlayerManager.instance.GetGunData().bulletDamage *= 0.5f;
        UIManager.instance.damageBonus.text = PlayerManager.instance.GetGunData().bulletDamage.ToString();
    }
}
