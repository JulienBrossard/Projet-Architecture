using System;
using UnityEngine;

public class FireRateCollectible : Collectible, ICollectable
{
    
    public void Collect()
    {
        PlayerManager.instance.GetGunData().fireRate -= buff.value;
        if (PlayerManager.instance.GetGunData().fireRate < PlayerManager.instance.GetGunData().minFireRate)
        {
            PlayerManager.instance.GetGunData().fireRate = PlayerManager.instance.GetGunData().minFireRate;
        }
        UIManager.instance.fireRateBonus.text = Math.Round(PlayerManager.instance.GetGunData().fireRate,2).ToString();
        Pooler.instance.DePop(gameObject.name.Replace("(Clone)", String.Empty), gameObject);
    }
}
