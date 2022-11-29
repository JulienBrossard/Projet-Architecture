using System;
using UnityEngine;

public class FireRateCollectible : Collectible, ICollectable
{
    public void Collect()
    {
        PlayerManager.instance.GetGunData().fireRate -= buff.value;
        if (PlayerManager.instance.GetGunData().fireRate < 0.05f)
        {
            PlayerManager.instance.GetGunData().fireRate = 0.05f;
        }
        Pooler.instance.DePop(gameObject.name.Replace("(Clone)", String.Empty), gameObject);
    }
}
