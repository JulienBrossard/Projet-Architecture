
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerManager : Entity
{
    public static PlayerManager instance;
    public PlayerCollision playerCollision;
    public PlayerMovement playerMovement;
    public PlayerShoot PlayerShoot;

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
    
    

    public override void Die()
    {
        Debug.Log("Game Over");
    }
    
    public IEnumerator TakeMultipleDamage(float damage, int time)
    {
        while (true)
        {
            TakeDamage(damage);
            yield return new WaitForSeconds(time);
        }
    }

    public PlayerData GetPlayerData()
    {
        return playerMovement.currentStats.playerData;
    }
    
    public GunData GetGunData()
    {
        return PlayerShoot.gun.gunCurrentStats.gunData;
    }

    public override void TakeDamage(float damage)
    {
        CameraManager.instance.CameraVignetteEffectOnHurt();
        base.TakeDamage(damage);
    }
}
