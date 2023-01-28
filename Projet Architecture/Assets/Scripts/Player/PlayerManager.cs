
using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerManager : Entity
{
    public static PlayerManager instance;
    public PlayerCollision playerCollision;
    public PlayerMovement playerMovement;
    public PlayerShoot playerShoot;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UIManager.instance.speedBonus.text = Math.Round(GetPlayerData().speed,2).ToString();
        UIManager.instance.fireRateBonus.text = Math.Round(GetGunData().fireRate,2).ToString();
        UIManager.instance.damageBonus.text = GetGunData().bulletDamage.ToString();
        UIManager.instance.playerHealth.text = entityData.health.ToString();
        currentStats.currentHealth = entityData.health;
    }
    
    

    public override void Die()
    {
        Debug.Log("Game Over");
        GameManager.Finish(false);
    }
    
    public IEnumerator TakeMultipleDamage(float damage, int time)
    {
        while (true)
        {
            TakeDamage(damage, time);
            yield return new WaitForSeconds(time);
        }
    }

    public PlayerData GetPlayerData()
    {
        return playerMovement.currentStats.playerData;
    }
    
    public GunData GetGunData()
    {
        return playerShoot.gun.gunCurrentStats.gunData;
    }

    public void TakeDamage(float damage, float time)
    {
        CameraManager.instance.CameraVignetteEffectOnHurt(time);
        TakeDamage(damage);
        UIManager.instance.playerHealth.text = currentStats.currentHealth.ToString();
    }

    public void StopDamage(GameObject enemy)
    {
        StopCoroutine(playerCollision.damageDictionary[enemy]);
        playerCollision.damageDictionary.Remove(enemy);
    }
}
